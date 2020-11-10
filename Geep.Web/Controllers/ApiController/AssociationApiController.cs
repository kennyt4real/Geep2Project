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
        private ICrudInteger<AssociationVm> _assoQuery;

        public AssociationApiController(ICrudInteger<AgentVm> agentRepo, ICrudInteger<AssociationBeneficiaryVm> assoBenQuery, IMapper mapper, ICrudInteger<DocumentVm> docQuery,
                                        IEntitiesManagement entitiesQuery, ICrudInteger<ClusterLocationVm> clusterQuery, ICrudInteger<BeneficiaryVm> repo, ICrudInteger<AssociationVm> assoQuery)
        {
            _agentRepo = agentRepo;
            _entitiesQuery = entitiesQuery;
            _assoBenQuery = assoBenQuery;
            _clusterQuery = clusterQuery;
            _repo = repo;
            _mapper = mapper;
            _docQuery = docQuery;
            _assoQuery = assoQuery;
        }

        [HttpPost(nameof(Post))]
        public async Task<IActionResult> Post([FromBody] AssociationVm vm)
        {
            var assoDocs = vm.Documents;
            var groupLeaders = vm.Beneficiaries;
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

                // Check if association already exist
                var association = await _assoQuery.GetByReferenceId(vm.ReferenceId);

                int associationId;
                if (association != null)
                {
                    vm.AssociationId = associationId = association.AssociationId;
                    association = CleanUpVm(vm);
                    await _assoQuery.AddOrUpdate(association);
                }
                else
                {
                    vm = CleanUpVm(vm);
                    associationId = await _entitiesQuery.AddAssociation(vm);
                }

                if (associationId > 0)
                {
                    try
                    {
                        if (assoDocs != null && assoDocs.Any())
                        {
                            foreach (var doc in assoDocs)
                            {
                                // Check if document already exist
                                var docInDb = await _entitiesQuery.GetDocumentByFileName(associationId, doc.File);
                                if (docInDb != null)
                                {
                                    continue;
                                }
                                doc.AssociationId = associationId;
                                await _docQuery.AddOrUpdate(doc);
                            }
                        }
                        if (groupLeaders != null && groupLeaders.Any())
                        {
                            foreach (var beneficiary in _mapper.Map<List<BeneficiaryVm>>(groupLeaders))
                            {
                                (int beneficiaryId, string message) response = (0, "");
                                var clusterLocation = await _clusterQuery.GetByReferenceId(beneficiary.ClusterLocationId);
                                beneficiary.ClusterLocationId = clusterLocation.ClusterLocationId;
                                beneficiary.AgentId = agent.AgentId;
                                beneficiary.AssociationId = associationId;
                                beneficiary.Agent = null;

                                //Check if Beneficiary already exist.
                                var beneficaiaryInDb = await _entitiesQuery.GetBeneficiaryByPhoneNumber(beneficiary.PhoneNumber);
                                if (beneficaiaryInDb != null && beneficaiaryInDb.BeneficiaryId > 0)
                                {
                                    beneficiary.BeneficiaryId = beneficaiaryInDb.BeneficiaryId;
                                    response = await _entitiesQuery.UpdateBeneficiary(beneficiary);
                                }
                                else
                                {
                                    response = await _entitiesQuery.AddBeneficiary(beneficiary);
                                }
                                if (response.beneficiaryId > 0)
                                {
                                    //Check if AssociationBeneficiary already exist in DB.
                                    var associationBeneficiary = await _entitiesQuery.GetAssociationBeneficiary(response.beneficiaryId, associationId);
                                    if (associationBeneficiary == null)
                                    {
                                        associationBeneficiary = new AssociationBeneficiaryVm { AssociationId = associationId, BeneficiaryId = response.beneficiaryId };
                                        await _assoBenQuery.AddOrUpdate(associationBeneficiary);

                                    }
                                }
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
        private AssociationVm CleanUpVm(AssociationVm vm)
        {
            vm.Agent = null;
            vm.Documents = null;
            vm.Beneficiaries = null;
            return vm;
        }
    }
}
