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
    public class ClusterLocationCQ : ICrudInteger<ClusterLocationVm>
    {
        private IRepo<ClusterLocation> _repo;
        public IMapper _mapper;

        public ClusterLocationCQ(IRepo<ClusterLocation> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ClusterLocationVm>> GetAll()
        {
            return _mapper.Map<List<ClusterLocationVm>>(await _repo.GetAll($"{nameof(State)}"));
        }

        public async Task<ClusterLocationVm> GetById(int id)
        {
            return _mapper.Map<ClusterLocationVm>(await _repo.GetFirstOrDeafultWithNoTracking(x=>x.ClusterLocationId.Equals(id),$"{nameof(State)}"));
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

    }
}
