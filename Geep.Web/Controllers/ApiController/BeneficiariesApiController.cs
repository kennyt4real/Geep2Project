using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geep.Web.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesApiController : ControllerBase
    {
        private ICrudInteger<BeneficiaryVm> _beneficiaryRepo;
        private ICrudInteger<AgentVm> _agentRepo;
        private IBeneficiaryManagement _beneficiaryQuery;

        public BeneficiariesApiController(ICrudInteger<BeneficiaryVm> beneficiaryRepo, ICrudInteger<AgentVm> agentRepo, 
                                            IBeneficiaryManagement beneficiaryQuery)
        {
            _beneficiaryRepo = beneficiaryRepo;
            _agentRepo = agentRepo;
            _beneficiaryQuery = beneficiaryQuery;
        }
      
        // POST: api/Beneficiary
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BeneficiaryVm vm)
        {
            if (ModelState.IsValid)
            {
                var agent = await _beneficiaryQuery.GetAgentByReferenceId(vm.Agent.ReferenceId);
                if (agent == null)
                {
                    agent = await _beneficiaryQuery.AddAgent(vm.Agent);
                    if (agent == null) 
                    {
                        return BadRequest(new { Message = "Something went wrong" });
                    }
                }
                vm.AgentId = agent.AgentId;
                vm.Agent = null;

                var response = await _beneficiaryRepo.AddOrUpdate(vm);
                if (response.Status)
                {
                    return Ok(new { Message = "Record created successfull" });
                }
            }
            return BadRequest(new { Message = "Record creation failed" });
            
        }
    }
}
