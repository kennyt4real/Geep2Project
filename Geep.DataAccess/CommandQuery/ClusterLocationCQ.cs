using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Geep.Common.Helpers;
using System.Linq;
using System.IO;

namespace Geep.DataAccess.CommandQuery
{
    public class ClusterLocationCQ : ICrudInteger<ClusterLocationVm>
    {
        private IRepo<ClusterLocation> _repo;
        public IMapper _mapper;
        private ICrudInteger<StateVm> _stateQuery;

        public ClusterLocationCQ(IRepo<ClusterLocation> repo, IMapper mapper, ICrudInteger<StateVm> stateQuery)
        {
            _repo = repo;
            _mapper = mapper;
            _stateQuery = stateQuery;
        }

        public async Task<List<ClusterLocationVm>> GetAll()
        {
            return _mapper.Map<List<ClusterLocationVm>>(await _repo.GetAll($"{nameof(State)}"));
        }

        public async Task<List<ClusterLocationVm>> GetAllById(int id)
        {
            return _mapper.Map<List<ClusterLocationVm>>(await _repo.GetAllById($"{nameof(State)}", x => x.State.StateId.Equals(id)));
        }

        public async Task<ClusterLocationVm> GetById(int id)
        {
            return _mapper.Map<ClusterLocationVm>(await _repo.GetFirstOrDeafultWithNoTracking(x=>x.ClusterLocationId.Equals(id),$"{nameof(State)}"));
        }

        public async Task<ClusterLocationVm> GetByReferenceId(int refId)
        {
            return _mapper.Map<ClusterLocationVm>(await _repo.GetFirstOrDeafultWithNoTracking(x => x.ReferenceId.Equals(refId), ""));
        }

        public async Task<ResponseVm> AddOrUpdate(ClusterLocationVm vm)
        {
            var model = _mapper.Map<ClusterLocation>(vm);
            if (model.ClusterLocationId > 0)
            {
                _repo.Update(model);
            }
            else
            {
                await _repo.Save(model);
            }
            return await _repo.SaveChangesAsync();
        }

        public async Task<ResponseVm> Delete(int id)
        {
            await _repo.Delete(id);
            return await _repo.SaveChangesAsync();

        }


        public async Task<ResponseVm> ExcelImport(IFormFile excelFile)
        {
            var res = new ResponseVm();
            var clusterList = new List<ClusterLocationVm>();
            if (excelFile.Length > 0)
            {
                var states = await _stateQuery.GetAll();
                var clusterLocationList = new List<ClusterLocationVm>();
                if (excelFile.FileName.EndsWith("xls", System.StringComparison.CurrentCulture)
                        || excelFile.FileName.EndsWith("xlsx", System.StringComparison.CurrentCulture))
                {
                    int recordCount = 0;
                    //string fileContentType = excelFile.ContentType;
                    //byte[] fileBytes = new byte[excelFile.Length];
                    var stream = new MemoryStream();
                    //var data = excelFile.InputStream.Read(fileBytes, 0, Convert.ToInt32(excelFile.Length));
                    await excelFile.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        ExcelValidation myExcel = new ExcelValidation();
                      
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            int requiredField = 3;
                            string validCheck = myExcel.ValidateExcel(noOfRow, workSheet, requiredField);

                            if (!validCheck.Equals("Success"))
                            {

                                string[] ssizes = validCheck.Split(' ');
                                string[] myArray = new string[2];
                                for (int i = 0; i < ssizes.Length; i++)
                                {
                                    myArray[i] = ssizes[i];
                                }
                                res.Message = $"Line/Row number {myArray[0]}  and column {myArray[1]} is not rightly formatted, Please Check for anomalies ";
                            }
                            for (int row = 2; row <= noOfRow; row++)
                            {
                                var refId = workSheet.Cells[row, 1].Value.ToString().Trim();
                                var clusterName = workSheet.Cells[row, 2].Value.ToString().Trim();
                                var stateId = workSheet.Cells[row, 3].Value.ToString().Trim();
                                try
                                {
                                var cluster = new ClusterLocationVm()
                                {
                                    ReferenceId = int.Parse(refId),
                                    Name = clusterName,
                                    StateId = states.FirstOrDefault(x => x.ReferenceId.Equals(int.Parse(stateId))).StateId,

                                    };
                                    clusterList.Add(cluster);
                                    recordCount++;
                                }
                                catch (Exception ex)
                                {
                                    res.Message = ex.Message;
                                }
                            }
                    }

                }
                
                await _repo.SaveMultiple(_mapper.Map<List<ClusterLocation>>(clusterList));
            }

            return await _repo.SaveChangesAsync();
        }

      
    }
}
