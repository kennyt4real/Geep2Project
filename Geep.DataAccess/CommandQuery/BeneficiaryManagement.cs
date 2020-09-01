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

        public BeneficiaryManagement(GeepDbContext db, IRepo<Beneficiary> repo, IMapper mapper, ICrudInteger<BeneficiaryVm> beneficiaryQuery,
            ICrudInteger<StateVm> stateQuery, ICrudInteger<ClusterLocationVm> clusterQuery)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
            _beneficiaryQuery = beneficiaryQuery;
            _stateQuery = stateQuery;
            _clusterQuery = clusterQuery;
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
                _db.Beneficiaries.Add(model);
                await _db.SaveChangesAsync();
                return (model.BeneficiaryId, "Beneficiary Added Successfully");

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
                boiField.ClusterLocation = clusterLocation.ReferenceId;

                if (!string.IsNullOrEmpty(beneficiary.Picture))
                    boiField.Picture = "data:image/jpeg;base64," + AzureHelper.FromAzureToBase64(beneficiary.Picture);

                if(!string.IsNullOrEmpty(beneficiary.FacialPicture))
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

                    await _beneficiaryQuery.AddOrUpdate(beneficiary);

                }
            }
        }
        public async Task<List<GeepAgent>> GetGeepAgents()
        {
            var response = await BOIHelper.GetGeepTeamUsers();
            var responseJson = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<GeepAgent>>(responseJson);

            return users;

        }

    }
}

