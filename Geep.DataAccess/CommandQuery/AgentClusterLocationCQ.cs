using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class AgentClusterLocationCQ : ICrudInteger<AgentClusterLocationVm>
    {
        private IRepo<AgentClusterLocation> _repo;
        public IMapper _mapper;

        public AgentClusterLocationCQ(IRepo<AgentClusterLocation> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AgentClusterLocationVm>> GetAll()
        {
            return _mapper.Map<List<AgentClusterLocationVm>>(await _repo.GetAll());
        }

        public async Task<AgentClusterLocationVm> GetById(int id)
        {
            return _mapper.Map<AgentClusterLocationVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(AgentClusterLocationVm vm)
        {
            var model = _mapper.Map<AgentClusterLocation>(vm);
            if (model.AgentClusterLocationId > 0)
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

    }
}
