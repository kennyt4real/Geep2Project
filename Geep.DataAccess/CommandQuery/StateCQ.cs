using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class StateCQ : ICrudInteger<StateVm>
    {
        private IRepo<State> _repo;
        public IMapper _mapper;

        public StateCQ(IRepo<State> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<StateVm>> GetAll()
        {
            return _mapper.Map<List<StateVm>>(await _repo.GetAll());
        }

        public async Task<StateVm> GetById(int id)
        {
            return _mapper.Map<StateVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(StateVm vm)
        {
            var model = _mapper.Map<State>(vm);
            if (model.StateId > 0)
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

        public Task<List<StateVm>> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
