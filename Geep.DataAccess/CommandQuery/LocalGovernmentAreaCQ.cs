using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class LocalGovernmentAreaCQ : ICrudInteger<LocalGovernmentAreaVm>
    {
        private IRepo<LocalGovernmentArea> _repo;
        public IMapper _mapper;

        public LocalGovernmentAreaCQ(IRepo<LocalGovernmentArea> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<LocalGovernmentAreaVm>> GetAll()
        {
            return _mapper.Map<List<LocalGovernmentAreaVm>>(await _repo.GetAll($"{nameof(State)}"));
        }

        public async Task<LocalGovernmentAreaVm> GetById(int id)
        {
            return _mapper.Map<LocalGovernmentAreaVm>(await _repo.GetFirstOrDeafultWithNoTracking(x=>x.LocalGovernmentAreaId.Equals(id),
                                        $"{nameof(State)}"));
        }
        public async Task<ResponseVm> AddOrUpdate(LocalGovernmentAreaVm vm)
        {
            var model = _mapper.Map<LocalGovernmentArea>(vm);
            if (model.LocalGovernmentAreaId > 0)
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
