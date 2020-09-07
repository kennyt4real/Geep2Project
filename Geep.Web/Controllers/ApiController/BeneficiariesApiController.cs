using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geep.Web.Controllers.ApiController
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BeneficiariesApiController : ControllerBase
    {
        private ICrudInteger<AgentVm> _agentRepo;
        private IBeneficiaryManagement _beneficiaryQuery;
        private ICrudInteger<AssociationBeneficiaryVm> _assoBenQuery;
        private ICrudInteger<ClusterLocationVm> _clusterQuery;
        private ICrudInteger<BeneficiaryVm> _repo;

        public BeneficiariesApiController(ICrudInteger<AgentVm> agentRepo, ICrudInteger<AssociationBeneficiaryVm> assoBenQuery,IBeneficiaryManagement beneficiaryQuery,
            ICrudInteger<ClusterLocationVm> clusterQuery, ICrudInteger<BeneficiaryVm> repo)
        {
            _agentRepo = agentRepo;
            _beneficiaryQuery = beneficiaryQuery;
            _assoBenQuery = assoBenQuery;
            _clusterQuery = clusterQuery;
            _repo = repo;
        }

        // POST: api/Beneficiary
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BeneficiaryVm vm)
        {
            if (ModelState.IsValid)
            {
                int associationId = 0;
                var agent = await _beneficiaryQuery.GetAgentByReferenceId(vm.Agent.ReferenceId);
                if (agent == null)
                {
                    agent = await _beneficiaryQuery.AddAgent(vm.Agent);
                    if (agent == null)
                    {
                        return BadRequest(new ResponseVm { Status=false, Message = "Agent Not found and Agent creation failed" });
                    }
                }
                if (vm.GroupName != null)
                {
                    var association = await _beneficiaryQuery.GetAssociationByAssociationName(vm.GroupName);
                    if (association != null)
                    {
                        vm.AssociationId = association.AssociationId;
                        associationId = association.AssociationId;
                        //return BadRequest(new ResponseVm {Status = false, Message = "Association not found" });
                    }
                }
                var clusterLocation = await _clusterQuery.GetByReferenceId(vm.ClusterLocationId);
                vm.ClusterLocationId = clusterLocation.ClusterLocationId;
                vm.AgentId = agent.AgentId;
                vm.Agent = null;

                (int beneficiaryId, string message) response = (0, "");
                //Check if Beneficiary already exist.
                var beneficaiaryInDb = await _repo.GetByReferenceId(vm.ReferenceId);
                if (beneficaiaryInDb != null && beneficaiaryInDb.BeneficiaryId > 0) 
                {
                    vm.BeneficiaryId = beneficaiaryInDb.BeneficiaryId;
                    response = await _beneficiaryQuery.UpdateBeneficiary(vm);
                }
                else
                {
                    response = await _beneficiaryQuery.AddBeneficiary(vm);
                }

                if (response.beneficiaryId > 0) 
                {
                    if (associationId > 0)
                    {
                        var associationBeneficiary = new AssociationBeneficiaryVm { AssociationId = associationId, BeneficiaryId = response.beneficiaryId };
                        await _assoBenQuery.AddOrUpdate(associationBeneficiary);
                    } 
                    return Ok(new ResponseVm { Status = true, Message = "Record created successfull" });
                }
                return BadRequest(new ResponseVm { Status = false, Message = $"Record creation failed.Reasons:{response.message}" });

            }
            return BadRequest(new ResponseVm {Status= false, Message = "Some responses are not Valid" });

        }
    }
}
