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
    public class BeneficiaryCQ : ICrudInteger<BeneficiaryVm>
    {
        private IRepo<Beneficiary> _repo;
        public IMapper _mapper;

        public BeneficiaryCQ(IRepo<Beneficiary> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<BeneficiaryVm>> GetAll()
        {
            return _mapper.Map<List<BeneficiaryVm>>(await _repo.GetAll($"{nameof(Agent)},{nameof(Association)},{nameof(ClusterLocation)}"));
        }

        public async Task<BeneficiaryVm> GetById(int id)
        {
            return _mapper.Map<BeneficiaryVm>(await _repo.GetFirstOrDeafultWithNoTracking(x=>x.BeneficiaryId.Equals(id),
                                                 $"{nameof(Agent)},{nameof(Association)},{nameof(ClusterLocation)}"));
        }
        public async Task<ResponseVm> AddOrUpdate(BeneficiaryVm vm)
        {
            var model = _mapper.Map<Beneficiary>(vm);
            if (model.BeneficiaryId > 0)
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
