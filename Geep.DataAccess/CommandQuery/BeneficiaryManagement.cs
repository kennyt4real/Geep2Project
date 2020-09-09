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

namespace Geep.DataAccess.CommandQuery
{
    public class BeneficiaryManagement : IBeneficiaryManagement
    {
        private IRepo<Beneficiary> _repo;
        private IMapper _mapper;
        private GeepDbContext _db;
        private ICrudInteger<BeneficiaryVm> _beneficiaryQuery;
        private ICrudInteger<StateVm> _stateQuery;
        private ICrudInteger<ClusterLocationVm> _clusterQuery;
        private ICrudInteger<AgentClusterLocationVm> _agentClusterQuery;
        private ICrudInteger<AgentVm> _agentQuery;

        public BeneficiaryManagement(GeepDbContext db, IRepo<Beneficiary> repo, IMapper mapper, ICrudInteger<BeneficiaryVm> beneficiaryQuery, ICrudInteger<AgentVm> agentQuery,
            ICrudInteger<StateVm> stateQuery, ICrudInteger<ClusterLocationVm> clusterQuery, ICrudInteger<AgentClusterLocationVm> agentClusterQuery)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
            _beneficiaryQuery = beneficiaryQuery;
            _stateQuery = stateQuery;
            _clusterQuery = clusterQuery;
            _agentClusterQuery = agentClusterQuery;
            _agentQuery = agentQuery;
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

        public async Task PushRecordsToWhiteList()
        {
            var beneficiaries = _mapper.Map<List<BeneficiaryVm>>(await _db.Beneficiaries.Include(x => x.Agent).Include(x => x.Association).AsNoTracking().Where(x => x.IsApprovedByWhiteList.Equals(false)).ToListAsync());
            int totalRecordPushed = 0;
            int approvedRecords = 0;
            int rejectedRecords = 0;
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


                var response = await BOIHelper.PusheToWhiteList(boiField);
                if (response.IsSuccessStatusCode)
                {
                    totalRecordPushed = totalRecordPushed + 1;
                    var json = await response.Content.ReadAsStringAsync();
                    JObject jobj = JObject.Parse(json);
                    beneficiary.PushedToWhiteList = true;
                    beneficiary.DateUpdated = DateTime.UtcNow;

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
                    var updatePortalVm = _mapper.Map<UpdateRecordOnPortalModel>(beneficiary);
                    var updateOnPortalResponse = await BOIHelper.UpdateRecordOnPortal(updatePortalVm);
                    var portalResponseJson = await updateOnPortalResponse.Content.ReadAsStringAsync();
                    var portalResponseModel = JsonConvert.DeserializeObject<PortalResponseVm>(portalResponseJson);
                    if (portalResponseModel.Data)
                        beneficiary.IsUpdatedOnPortal = true;

                    beneficiary.Agent = null;
                    beneficiary.ClusterLocationVm = null;
                    beneficiary.Association = null;
                    await _beneficiaryQuery.AddOrUpdate(beneficiary);

                }
            }
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
                        var cluster = await _clusterQuery.GetByReferenceId(clusterId);

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
                    portalAgent.Agent.ReferenceId = "MOB" + "-" + portalAgent.Agent.Id.ToString().PadLeft(5, '0');
                    agent = await AddAgent(portalAgent.Agent);
                    if (agent != null)
                    {
                        if (!emails.Contains(agent.Email))
                            emails.Add(agent.Email);
                        foreach (var clusterId in vm.ClusterLocationIds)
                        {
                            var cluster = await _clusterQuery.GetByReferenceId(clusterId);
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
            var res = await BOIHelper.AddUsersToClusters(new AddUserToClusterModel
            {
                Emails = string.Join(",", emails.ToArray()).ToLower().Remove(' ', '-'),
                Clusters = string.Join(",", clusters.ToArray()).ToLower().Remove(' ', '-')
            });
            var resJson = await res.Content.ReadAsStringAsync();
            var portalRes = JsonConvert.DeserializeObject<PortalAgent>(resJson);
            if (portalRes.StatusCode.Equals(200))
            {
                return new ResponseVm { Status = true, Message = "Agents Added to Clusters Successfully..." };
            }
            return new ResponseVm { Status = false, Message = "Oops,  Something went wrong" };
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

