using AutoMapper;
using Geep.Common.Helpers;
using Geep.DataAccess.Context;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geep.Common.ExtensionMethods;
using System.Text;

namespace Geep.DataAccess.CommandQuery
{
    public class EntitiesManagement : IEntitiesManagement
    {
        private IRepo<Beneficiary> _repo;
        private IMapper _mapper;
        private GeepDbContext _db;
        private ICrudInteger<BeneficiaryVm> _beneficiaryQuery;
        private ICrudInteger<StateVm> _stateQuery;
        private ICrudInteger<ClusterLocationVm> _clusterQuery;
        private ICrudInteger<AgentClusterLocationVm> _agentClusterQuery;
        private ICrudInteger<AgentVm> _agentQuery;
        private readonly ICrudInteger<LocalGovernmentAreaVm> _lgaQuery;
        private readonly ICrudInteger<AssociationVm> _assoQuery;
        private readonly IEmailSender _emailService;

        public EntitiesManagement(GeepDbContext db, IRepo<Beneficiary> repo, IMapper mapper, ICrudInteger<BeneficiaryVm> beneficiaryQuery,
                                  ICrudInteger<AgentVm> agentQuery, ICrudInteger<StateVm> stateQuery, ICrudInteger<ClusterLocationVm> clusterQuery,
                                  ICrudInteger<AgentClusterLocationVm> agentClusterQuery, ICrudInteger<LocalGovernmentAreaVm> lgaQuery,
                                  ICrudInteger<AssociationVm> assoQuery, IEmailSender emailService)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
            _beneficiaryQuery = beneficiaryQuery;
            _stateQuery = stateQuery;
            _clusterQuery = clusterQuery;
            _agentClusterQuery = agentClusterQuery;
            _agentQuery = agentQuery;
            _lgaQuery = lgaQuery;
            _assoQuery = assoQuery;
            _emailService = emailService;
        }

        public async Task<List<BeneficiaryVm>> GetBeneficiaryByAssociationId(int id)
        {
            return _mapper.Map<List<BeneficiaryVm>>(await _repo.GetAllById($"{nameof(Association)},{nameof(Models.Core.Agent)}", x => x.AssociationId.Equals(id)));
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

        public async Task<(int beneficiaryId, string message)> AddBeneficiary(BeneficiaryVm vm)
        {
            try
            {
                if (vm.LGAId > 0)
                {
                    var lga = await _lgaQuery.GetByReferenceId(vm.LGAId);
                    vm.LGAId = lga.LocalGovernmentAreaId;
                }
                var model = _mapper.Map<Beneficiary>(vm);
                model.DateCreated = DateTime.Now;

                _db.Beneficiaries.Add(model);
                await _db.SaveChangesAsync();
                return (model.BeneficiaryId, "Beneficiary Added Successfully");

            }
            catch (Exception ex)
            {
                return (0, ex.ToFormattedString());
            }
        }

        public async Task<(int beneficiaryId, string message)> UpdateBeneficiary(BeneficiaryVm vm)
        {
            try
            {
                if (vm.LGAId > 0)
                {
                    var lga = await _lgaQuery.GetByReferenceId(vm.LGAId);
                    vm.LGAId = lga.LocalGovernmentAreaId;
                }
                var model = _mapper.Map<Beneficiary>(vm);
                model.DateUpdated = DateTime.Now;

                _db.Beneficiaries.Update(model);
                await _db.SaveChangesAsync();
                return (model.BeneficiaryId, "Beneficiary Updated Successfully");

            }
            catch (Exception ex)
            {
                return (0, ex.ToFormattedString());
            }
        }

        public async Task<AssociationVm> GetAssociationByAssociationName(string groupName)
        {
            return _mapper.Map<AssociationVm>(await _db.Associations.AsNoTracking().FirstOrDefaultAsync(x => x.AssociationName.ToUpper().Trim().Equals(groupName.ToUpper().Trim())));
        }
        public async Task CreateGroupOnWhiteList(string userEmail)
        {
            var associations = _mapper.Map<List<AssociationVm>>(await _db.Associations
                                                                    .Include(x => x.Beneficiaries)
                                                                    .Include(x => x.LocalGovernmentArea)
                                                                    .Include(x => x.Documents)
                                                                    .AsNoTracking()
                                                                    .Where(x => x.IsApprovedByWhiteList.Equals(false))
                                                                    .ToListAsync());
            int totalRecordPushed = 0;
            int approvedRecords = 0;
            int rejectedRecords = 0;
            try
            {
                foreach (var association in associations)
                {

                    var groupLga = await _db.LocalGovernmentAreas.Include(x => x.State).AsNoTracking().FirstOrDefaultAsync(x => x.LocalGovernmentAreaId.Equals(association.LocalGovernmentAreaId));
                    var groupField = _mapper.Map<GroupFields>(association);
                    groupField.StateId = groupLga.State.ReferenceId.ToString();
                    groupField.LGAId = groupLga.ReferenceId.ToString();

                    groupField.GroupExcoInformations = _mapper.Map<List<ExcoInformation>>(association.Beneficiaries);
                    foreach (var exco in groupField.GroupExcoInformations)
                    {
                        var excoLga = await _db.LocalGovernmentAreas.Include(x => x.State).AsNoTracking().FirstOrDefaultAsync(x => x.LocalGovernmentAreaId.Equals(exco.LGAId));
                        exco.LGAId = excoLga.ReferenceId;
                        exco.StateId = excoLga.State.ReferenceId;
                    }
                    var groupDoc = association.Documents.FirstOrDefault(x => x.FileType.Equals("mou"));
                    groupDoc.File = AzureHelper.FromAzureToBase64(groupDoc.File);
                    groupField.Documents = new DocumentVm[] { groupDoc };

                    var groupTrades = association.TradeType.Split(',');
                    groupField.GroupTradeTypes = new List<int>();
                    foreach (var item in groupTrades)
                    {
                        groupField.GroupTradeTypes.Add(int.Parse(item));
                    }

                    groupField.EnumeratorIds = new List<int> { int.Parse(association.EnumeratorId) };

                    var response = await BOIHelper.PusheToWhiteList(groupField);
                    if (response.IsSuccessStatusCode)
                    {
                        totalRecordPushed = totalRecordPushed + 1;
                        var json = await response.Content.ReadAsStringAsync();
                        JObject jobj = JObject.Parse(json);
                        association.PushedToWhiteList = true;

                        if (jobj["status"].ToString() == "200")
                        {
                            approvedRecords = approvedRecords + 1;
                            association.IsApprovedByWhiteList = true;
                            association.ReferenceKey = jobj["data"]["id"].ToString();

                        }
                        else if (jobj["status"].ToString() == "401")
                        {
                            rejectedRecords = rejectedRecords + 1;
                            association.RejectionReason = "Rejected by whitelist for these reasons:" + " " + jobj["message"].ToString();
                        }
                        else
                        {

                            if (jobj["data"] == null || jobj["data"]["id"] == null)
                            {
                                association.RejectionReason = "Rejected by whitelist for these reasons:" + " " + jobj["message"].ToString();

                            }
                        }
                        association.DateUpdated = DateTime.UtcNow;
                        association.Agent = null;
                        association.Documents = null;
                        association.Beneficiaries = null;

                        var updatePortalVm = _mapper.Map<UpdateRecordOnPortalModel>(association);
                        var updateOnPortalResponse = await BOIHelper.UpdateRecordOnPortal(updatePortalVm);
                        var portalResponseJson = await updateOnPortalResponse.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(portalResponseJson))
                        {
                            var portalResponseModel = JsonConvert.DeserializeObject<PortalResponseVm>(portalResponseJson);
                            if (portalResponseModel.Data)
                            {
                                association.IsUpdatedOnPortal = true;
                            }
                            await _assoQuery.AddOrUpdate(association);
                        }
                        else
                        {
                            await _assoQuery.AddOrUpdate(association);

                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            await _emailService.SendEmailAsync(userEmail, "Pushed Records Summary",
                                                   $"Summary of the records pushed to the whitelist is as follows.<br/>" +
                                                   $"Total pushed records: {totalRecordPushed}.<br/>" +
                                                   $"Approved records: {approvedRecords}.<br/>" +
                                                   $"Rejected records: {rejectedRecords}.<br/>");
        }

        public async Task PushBeneficiaryRecordsToWhiteList(string userEmail)
        {
            var beneficiaries = _mapper.Map<List<BeneficiaryVm>>(await _db.Beneficiaries
                                                                            .Include(x => x.Agent)
                                                                            .Include(x => x.Association)
                                                                            .AsNoTracking()
                                                                            .Where(x => x.IsApprovedByWhiteList.Equals(false))
                                                                            .ToListAsync());
            int totalRecordPushed = 0;
            int approvedRecords = 0;
            int rejectedRecords = 0;
            try
            {
                foreach (var beneficiary in beneficiaries)
                {

                    var boiField = _mapper.Map<BOIFields>(beneficiary);
                    var clusterLocation = await _clusterQuery.GetById(beneficiary.ClusterLocationId);
                    boiField.StateId = clusterLocation.State.ReferenceId;

                    boiField.ClusterLocationId = clusterLocation.ReferenceId;

                    if (!string.IsNullOrEmpty(beneficiary.Picture))
                        boiField.Picture = "data:image/jpeg;base64," + AzureHelper.FromAzureToBase64(beneficiary.Picture);

                    if (!string.IsNullOrEmpty(beneficiary.FacialPicture))
                        boiField.FacialPicture = "data:image/jpeg;base64," + AzureHelper.FromAzureToBase64(beneficiary.FacialPicture);

                    boiField.Agent = new AgentVm[] { beneficiary.Agent };

                    boiField.AggregatorId = "1";

                    var response = await BOIHelper.PusheToWhiteList(boiField);
                    if (response.IsSuccessStatusCode)
                    {
                        totalRecordPushed = totalRecordPushed + 1;
                        var json = await response.Content.ReadAsStringAsync();
                        JObject jobj = JObject.Parse(json);
                        beneficiary.PushedToWhiteList = true;

                        if (jobj["status"].ToString() == "200")
                        {
                            beneficiary.IsApprovedByWhiteList = true;
                            beneficiary.ReferenceKey = jobj["data"]["id"].ToString();
                            approvedRecords = approvedRecords + 1;

                        }
                        else if (jobj["status"].ToString() == "401")
                        {
                            beneficiary.RejectionReason = "Rejected by whitelist for these reasons:" + " " + jobj["message"].ToString();
                            rejectedRecords = rejectedRecords + 1;
                        }
                        else
                        {

                            if (jobj["data"] == null || jobj["data"]["id"] == null)
                            {
                                beneficiary.RejectionReason = "Rejected by whitelist for these reasons:" + " " + jobj["message"].ToString();

                                rejectedRecords = rejectedRecords + 1;
                            }
                        }
                        beneficiary.DateUpdated = DateTime.UtcNow;
                        beneficiary.Agent = null;
                        beneficiary.ClusterLocationVm = null;
                        beneficiary.Association = null;
                        var updatePortalVm = _mapper.Map<UpdateRecordOnPortalModel>(beneficiary);
                        var updateOnPortalResponse = await BOIHelper.UpdateRecordOnPortal(updatePortalVm);
                        var portalResponseJson = await updateOnPortalResponse.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(portalResponseJson))
                        {
                            var portalResponseModel = JsonConvert.DeserializeObject<PortalResponseVm>(portalResponseJson);
                            if (portalResponseModel.Data)
                            {
                                beneficiary.IsUpdatedOnPortal = true;
                            }
                            await _beneficiaryQuery.AddOrUpdate(beneficiary);
                        }
                        else
                        {
                            await _beneficiaryQuery.AddOrUpdate(beneficiary);

                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            await _emailService.SendEmailAsync(userEmail, "Pushed Records Summary",
                                           $"Summary of the records pushed to the whitelist is as follows.<br/>" +
                                           $"Total pushed records: {totalRecordPushed}.<br/>" +
                                           $"Approved records: {approvedRecords}.<br/>" +
                                           $"Rejected records: {rejectedRecords}.<br/>");
        }
        public async Task<List<GeepAgent>> GetGeepAgents()
        {
            var response = await BOIHelper.GetGeepTeamUsers();
            var responseJson = await response.Content.ReadAsStringAsync();
            var teamUserResponse = JsonConvert.DeserializeObject<TeamUsersPortalResponse>(responseJson);


            return teamUserResponse.Agents;

        }

        public async Task<ResponseVm> AddAgentsToClusters(AgentClusterLocationVm vm)
        {
            var emails = new List<string>();
            var clusters = new List<string>();

            foreach (var userId in vm.AgentIds)
            {
                var agent = await GetAgentByReferenceId("MOB" + "-" + userId.ToString().PadLeft(5, '0'));

                if (agent != null)
                {
                    if (!emails.Contains(agent.Email))
                        emails.Add(agent.Email);
                    foreach (var clusterId in vm.ClusterLocationIds)
                    {
                        var cluster = await _clusterQuery.GetById(clusterId);

                        if (cluster != null && !await AgentIsAlreadyAddedToCluster(agent.AgentId, cluster.ClusterLocationId))
                        {
                            if (!clusters.Contains(cluster.Name))
                                clusters.Add(cluster.Name);
                            vm.AgentId = agent.AgentId;
                            vm.ClusterLocationId = cluster.ClusterLocationId;
                            await _agentClusterQuery.AddOrUpdate(vm);
                        }
                    }
                }
                else
                {
                    var agentResponse = await BOIHelper.GetUserById(userId);
                    var agentResponsJson = await agentResponse.Content.ReadAsStringAsync();
                    var portalAgent = JsonConvert.DeserializeObject<PortalAgent>(agentResponsJson);
                    portalAgent.UserDetails.ReferenceId = "MOB" + "-" + portalAgent.UserDetails.Id.ToString().PadLeft(5, '0');
                    agent = await AddAgent(_mapper.Map<AgentVm>(portalAgent.UserDetails));
                    if (agent != null)
                    {
                        if (!emails.Contains(agent.Email))
                            emails.Add(agent.Email);
                        foreach (var clusterId in vm.ClusterLocationIds)
                        {
                            var cluster = await _clusterQuery.GetById(clusterId);
                            if (cluster != null)
                            {
                                if (!clusters.Contains(cluster.Name))
                                    clusters.Add(cluster.Name);
                                vm.AgentId = agent.AgentId;
                                vm.ClusterLocationId = cluster.ClusterLocationId;
                                await _agentClusterQuery.AddOrUpdate(vm);
                            }

                        }
                    }
                }
            }
            if (emails.Any() && clusters.Any())
            {

                var emailString = new StringBuilder();
                var clusterString = new StringBuilder();
                foreach (var email in emails)
                {
                    emailString.Append(email.ToLower());
                    if (emails.IndexOf(email) == emails.Count() - 1)
                        continue;
                    emailString.Append(',');
                }
                foreach (var cluster in clusters)
                {
                    clusterString.Append(cluster.ToLower());
                    if (cluster.IndexOf(cluster) == clusters.Count() - 1)
                        continue;
                    clusterString.Append(',');
                }
                var res = await BOIHelper.AddUsersToClusters(new AddUserToClusterModel
                {
                    Emails = emailString.ToString(),
                    Clusters = clusterString.ToString()
                }); ;
                var resJson = await res.Content.ReadAsStringAsync();
                var portalRes = JsonConvert.DeserializeObject<PortalAgent>(resJson);
                if (portalRes.StatusCode.Equals(200))
                {
                    return new ResponseVm { Status = true, Message = "Agents Added to Clusters Successfully..." };
                }
            }

            return new ResponseVm { Status = false, Message = "Oops,  Something went wrong" };
        }
        public async Task<BeneficiaryVm> GetBeneficiaryByPhoneNumber(string phoneNumber)
        {
            return _mapper.Map<BeneficiaryVm>(await _db.Beneficiaries.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber)));
        }

        public async Task AddAssociationDocument(DocumentVm vm)
        {
            try
            {
                var model = _mapper.Map<Document>(vm);
                _db.Documents.Add(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddAssociation(AssociationVm vm)
        {
            try
            {
                var model = _mapper.Map<Association>(vm);
                _db.Associations.Add(model);
                await _db.SaveChangesAsync();
                return model.AssociationId;

            }
            catch (Exception ex)
            {
                throw;
            }


        }
        public async Task<DocumentVm> GetDocumentByFileName(int associationId, string file)
        {
            try
            {
                return _mapper.Map<DocumentVm>(await _db.Documents.FirstOrDefaultAsync(x => x.AssociationId.Equals(associationId) && x.File.Equals(file)));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<AssociationBeneficiaryVm> GetAssociationBeneficiary(int beneficiaryId, int associationId)
        {
            try
            {
                return _mapper.Map<AssociationBeneficiaryVm>(await _db.AssociationBeneficiaries
                                                        .FirstOrDefaultAsync(x => x.BeneficiaryId.Equals(beneficiaryId)
                                                        && x.AssociationId.Equals(associationId)));

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        private async Task<bool> AgentIsAlreadyAddedToCluster(int agentId, int clusterId)
        {
            var agentCluster = await _db.AgentClusterLocations.AsNoTracking().FirstOrDefaultAsync(x => x.AgentId.Equals(agentId) && x.ClusterLocationId.Equals(clusterId));
            if (agentCluster == null)
                return false;
            return true;
        }



    }
}

