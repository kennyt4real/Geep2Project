using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class AssociationBeneficiaryCQ : ICrudInteger<AssociationBeneficiaryVm>
    {
        private IRepo<AssociationBeneficiary> _repo;
        public IMapper _mapper;

        public AssociationBeneficiaryCQ(IRepo<AssociationBeneficiary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AssociationBeneficiaryVm>> GetAll()
        {
            return _mapper.Map<List<AssociationBeneficiaryVm>>(await _repo.GetAll($"{nameof(Beneficiary)},{nameof(Association)}"));
        }

        public async Task<AssociationBeneficiaryVm> GetById(int id)
        {
            return _mapper.Map<AssociationBeneficiaryVm>(await _repo.GetFirstOrDeafultWithNoTracking(x=>x.AssociationBeneficiaryId.Equals(id),
                                                                             $"{nameof(Beneficiary)},{nameof(Association)}"));
        }
        public async Task<ResponseVm> AddOrUpdate(AssociationBeneficiaryVm vm)
        {
            var model = _mapper.Map<AssociationBeneficiary>(vm);
            if (model.AssociationBeneficiaryId > 0)
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

        public Task<List<AssociationBeneficiaryVm>> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AssociationBeneficiaryVm> GetByReferenceId(int refId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseVm> ExcelImport(IFormFile excelFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
