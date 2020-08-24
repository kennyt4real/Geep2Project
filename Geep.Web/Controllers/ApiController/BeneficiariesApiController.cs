﻿using System;
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
                        return BadRequest(new ResponseVm { Status=false, Message = "Agent Not found and Agent creation failed" });
                    }
                }
                if (vm.GroupName != null)
                {
                    var association = await _beneficiaryQuery.GetAssociationByAssociationName(vm.GroupName);
                    if (association != null)
                    {
                        vm.AssociationId = association.AssociationId;
                        //return BadRequest(new ResponseVm {Status = false, Message = "Association not found" });
                    }
                }
                vm.AgentId = agent.AgentId;
                vm.Agent = null;


                var response = await _beneficiaryRepo.AddOrUpdate(vm);
                if (response.Status)
                {
                    return Ok(new ResponseVm { Status = true, Message = "Record created successfull" });
                }
                return BadRequest(new ResponseVm { Status = false, Message = $"Record creation failed {response.Message}" });

            }
            return BadRequest(new ResponseVm {Status= false, Message = "Record creation failed" });

        }
    }
}
