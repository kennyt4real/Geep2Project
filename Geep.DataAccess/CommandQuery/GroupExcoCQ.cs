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
    public class GroupExcoCQ : ICrudInteger<GroupExcoVm>
    {
        private IRepo<GroupExco> _repo;
        public IMapper _mapper;

        public GroupExcoCQ(IRepo<GroupExco> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GroupExcoVm>> GetAll()
        {
            return _mapper.Map<List<GroupExcoVm>>(await _repo.GetAll());
        }

        public async Task<GroupExcoVm> GetById(int id)
        {
            return _mapper.Map<GroupExcoVm>(await _repo.GetById(id));
        }

        public async Task<GroupExcoVm> GetByReferenceId(int refId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseVm> AddOrUpdate(GroupExcoVm vm)
        {
            var model = _mapper.Map<GroupExco>(vm);
            if (model.GroupExcoId > 0)
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

        public Task<List<GroupExcoVm>> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseVm> ExcelImport(IFormFile excelFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
