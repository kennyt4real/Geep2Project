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
    public class AssociationCQ : ICrudInteger<AssociationVm>
    {
        private IRepo<Association> _repo;
        public IMapper _mapper;

        public AssociationCQ(IRepo<Association> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AssociationVm>> GetAll()
        {
            return _mapper.Map<List<AssociationVm>>(await _repo.GetAll($"{nameof(LocalGovernmentArea)}.{nameof(State)}"));
        }

        public async Task<AssociationVm> GetById(int id)
        {
            return _mapper.Map<AssociationVm>(await _repo.GetFirstOrDeafultWithNoTracking(x => x.AssociationId.Equals(id),
                                                        $"{nameof(LocalGovernmentArea)}.{nameof(State)}"));
        }
        public async Task<AssociationVm> GetByReferenceId(int refId)
        {
            return _mapper.Map<AssociationVm>(await _repo.GetFirstOrDeafultWithNoTracking(x => x.AssociationRefId.Equals(refId), ""));
        }

        public async Task<ResponseVm> AddOrUpdate(AssociationVm vm)
        {
            var model = _mapper.Map<Association>(vm);
            if (model.AssociationId > 0)
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

        public Task<List<AssociationVm>> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseVm> ExcelImport(IFormFile excelFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
