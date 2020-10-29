using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geep.Web.Controllers.ApiController
{
    [ApiController]
    [Route("api/Beneficiary")]
    [Produces("application/json")]
    public class BeneficiaryApiController : ControllerBase
    {
        private ICrudInteger<AgentVm> _agentRepo;
        private IEntitiesManagement _entityQuery;
        private ICrudInteger<AssociationBeneficiaryVm> _assoBenQuery;
        private ICrudInteger<ClusterLocationVm> _clusterQuery;
        private ICrudInteger<BeneficiaryVm> _repo;
        private IMapper _mapper;

        public BeneficiaryApiController(ICrudInteger<AgentVm> agentRepo, ICrudInteger<AssociationBeneficiaryVm> assoBenQuery,IEntitiesManagement entityQuery,
            ICrudInteger<ClusterLocationVm> clusterQuery, ICrudInteger<BeneficiaryVm> repo, IMapper mapper)
        {
            _agentRepo = agentRepo;
            _entityQuery = entityQuery;
            _assoBenQuery = assoBenQuery;
            _clusterQuery = clusterQuery;
            _repo = repo;
            _mapper = mapper;
        }

        // POST: api/Beneficiary
        [HttpPost(nameof(Post))]
        public async Task<IActionResult> Post([FromBody] CreateBeneficiary vm)
        {
            if (ModelState.IsValid)
            {

                int associationId = 0;
                var agent = await _entityQuery.GetAgentByReferenceId(vm.Agent.ReferenceId);
                if (agent == null)
                {
                    agent = await _entityQuery.AddAgent(vm.Agent);
                    if (agent == null)
                    {
                        return BadRequest(new ResponseVm { Status=false, Message = "Agent Not found and Agent creation failed" });
                    }
                }
                if (!string.IsNullOrEmpty(vm.GroupName)) 
                {
                    var association = await _entityQuery.GetAssociationByAssociationName(vm.GroupName);
                    if (association != null)
                    {
                        vm.AssociationId = association.AssociationId;
                        associationId = association.AssociationId;
                        //return BadRequest(new ResponseVm {Status = false, Message = "Association not found" });
                    }
                }
               
                var beneficiary =_mapper.Map<BeneficiaryVm>(vm);
                var clusterLocation = await _clusterQuery.GetByReferenceId(vm.ClusterLocationId);
                beneficiary.ClusterLocationId = clusterLocation.ClusterLocationId;
                beneficiary.AgentId = agent.AgentId;
                beneficiary.Agent = null;
                (int beneficiaryId, string message) response = (0, "");
                //Check if Beneficiary already exist.
                var beneficaiaryInDb = await _repo.GetByReferenceId(vm.ReferenceId);
                if (beneficaiaryInDb != null && beneficaiaryInDb.BeneficiaryId > 0) 
                {
                    beneficiary.BeneficiaryId = beneficaiaryInDb.BeneficiaryId;
                    response = await _entityQuery.UpdateBeneficiary(beneficiary);
                }
                else
                {
                    response = await _entityQuery.AddBeneficiary(beneficiary);
                }

                if (response.beneficiaryId > 0) 
                {
                    if (associationId > 0)
                    {
                        //Check if AssociationBeneficiary already exist in DB.
                        var associationBeneficiary = await _entityQuery.GetAssociationBeneficiary(response.beneficiaryId, associationId);
                        if (associationBeneficiary == null)
                        {
                            associationBeneficiary = new AssociationBeneficiaryVm { AssociationId = associationId, BeneficiaryId = response.beneficiaryId };
                            await _assoBenQuery.AddOrUpdate(associationBeneficiary);

                        }
                    } 
                    return Ok(new ResponseVm { Status = true, Message = "Record created successfull" });
                }
                return BadRequest(new ResponseVm { Status = false, Message = $"Record creation failed.Reasons:{response.message}" });

            }
            return BadRequest(new ResponseVm {Status= false, Message = "Some responses are not Valid" });

        }

        
    }
}
