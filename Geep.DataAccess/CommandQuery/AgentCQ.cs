using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class AgentCQ : ICrudInteger<AgentVm>
    {
        private readonly IRepo<Agent> _repo;
        private readonly IMapper _mapper;
        public AgentCQ(IRepo<Agent> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AgentVm>> GetAll()
        {
            return _mapper.Map<List<AgentVm>>(await _repo.GetAll());
        }

        public async Task<AgentVm> GetById(int id)
        {
            return _mapper.Map<AgentVm>(await _repo.GetFirstOrDeafultWithNoTracking(x=>x.AgentId.Equals(id),""));
        }
        public async  Task<ResponseVm> AddOrUpdate(AgentVm vm)
        {
            var model = _mapper.Map<Models.Core.Agent>(vm);

            if (model.AgentId > 0)
            {
                _repo.Update(model);
            }
            else
            {
                await _repo.Save(model);
            }
            return await _repo.SaveChangesAsync();
        }

        public async Task<ResponseVm> Delete(int t)
        {
            await _repo.Delete(t);
            return await _repo.SaveChangesAsync();
        }

        public async Task<List<AgentVm>> GetAllById(int id)
        {
            return _mapper.Map<List<AgentVm>>(await _repo.GetAllById("", x => x.LocalGovtRefId.Equals(id)));
        }

        public Task<AgentVm> GetByReferenceId(int refId)
        {
            throw new NotImplementedException();
        }
    }
}
