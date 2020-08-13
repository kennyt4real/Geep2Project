using AutoMapper;
using Geep.DataAccess.Context;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels.CoreVm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class BeneficiaryManagement : IBeneficiaryManagement
    {
        private IRepo<Beneficiary> _repo;
        private IMapper _mapper;
        private GeepDbContext _db;

        public BeneficiaryManagement(GeepDbContext db, IRepo<Beneficiary> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
        }

        public async Task<List<BeneficiaryVm>> GetBeneficiaryByAssociationId(int id)
        {
            return _mapper.Map<List<BeneficiaryVm>>(await _repo.GetAllById($"{nameof(Association)},{nameof(Agent)}", x => x.AssociationId.Equals(id)));
        }

        public async Task<List<BeneficiaryVm>> GetBeneficiaryByAgentId(int id)
        {
            return _mapper.Map<List<BeneficiaryVm>>(await _repo.GetAllById($"{nameof(Association)},{nameof(Agent)}", x => x.AgentId.Equals(id)));

        }



        public async Task<AgentVm> GetAgentByReferenceId(string id)
        {
            return _mapper.Map<AgentVm>(await _db.Agents.AsNoTracking().FirstOrDefaultAsync(x => x.ReferenceId.Equals(id)));

        }
        public async Task<AgentVm> AddAgent(AgentVm vm)
        {
            try
            {
                var model = _mapper.Map<Agent>(vm);
                _db.Agents.Add(model);
                await _db.SaveChangesAsync();
                return _mapper.Map<AgentVm>(model);

            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

    }
}
