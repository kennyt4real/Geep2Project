using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Mvc;

namespace Geep.Web.Controllers.ApiController
{
    [ApiController]
    [Route("api/Group")]
    [Produces("application/json")]
    public class AssociationApiController : Controller
    {
        private ICrudInteger<AgentVm> _agentRepo;
        private IEntitiesManagement _entitiesQuery;
        private ICrudInteger<AssociationBeneficiaryVm> _assoBenQuery;
        private ICrudInteger<ClusterLocationVm> _clusterQuery;
        private ICrudInteger<BeneficiaryVm> _repo;
        private IMapper _mapper;
        private ICrudInteger<DocumentVm> _docQuery;

        public AssociationApiController(ICrudInteger<AgentVm> agentRepo, ICrudInteger<AssociationBeneficiaryVm> assoBenQuery, IMapper mapper, ICrudInteger<DocumentVm> docQuery,
                                        IEntitiesManagement entitiesQuery, ICrudInteger<ClusterLocationVm> clusterQuery, ICrudInteger<BeneficiaryVm> repo)
        {
            _agentRepo = agentRepo;
            _entitiesQuery = entitiesQuery;
            _assoBenQuery = assoBenQuery;
            _clusterQuery = clusterQuery;
            _repo = repo;
            _mapper = mapper;
            _docQuery = docQuery;
        }

        [HttpPost(nameof(Post))]
        public async Task<IActionResult> Post([FromBody] AssociationVm vm)
        {


            if (ModelState.IsValid)
            {
                var agent = await _entitiesQuery.GetAgentByReferenceId(vm.Agent.ReferenceId);
                if (agent == null)
                {
                    agent = await _entitiesQuery.AddAgent(vm.Agent);
                    if (agent == null)
                    {
                        return BadRequest(new ResponseVm { Status = false, Message = "Agent Not found and Agent creation failed" });
                    }
                }
                await _docQuery.AddOrUpdate(vm.Document);
                var associationId = await _entitiesQuery.AddAssociation(vm);
                if (associationId > 0)
                {
                    try
                    {
                        foreach (var beneficiary in vm.Beneficiaries)
                        {
                            var clusterLocation = await _clusterQuery.GetByReferenceId(beneficiary.ClusterLocationId);
                            beneficiary.ClusterLocationId = clusterLocation.ClusterLocationId;
                            beneficiary.AgentId = agent.AgentId;
                            beneficiary.Agent = null;

                            //Check if Beneficiary already exist.
                            var beneficaiaryInDb = await _entitiesQuery.GetBeneficiaryByPhoneNumber(beneficiary.PhoneNumber);
                            if (beneficaiaryInDb != null && beneficaiaryInDb.BeneficiaryId > 0)
                            {
                                beneficiary.BeneficiaryId = beneficaiaryInDb.BeneficiaryId;
                                await _entitiesQuery.UpdateBeneficiary(beneficiary);
                            }
                            else
                            {
                                await _entitiesQuery.AddBeneficiary(beneficiary);
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        return BadRequest(new ResponseVm { Status = false, Message = ex.Message });
                    }

                    return Ok(new ResponseVm { Status = true, Message = "Record created successfull" });

                }

            }
            return BadRequest(new ResponseVm { Status = false, Message = "Some responses are not Valid" });

        }
    }
}
