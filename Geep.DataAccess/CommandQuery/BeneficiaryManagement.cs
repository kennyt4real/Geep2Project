using AutoMapper;
using Geep.Common.BOIHelpers;
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
using System.Text;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class BeneficiaryManagement : IBeneficiaryManagement
    {
        private IRepo<Beneficiary> _repo;
        private IMapper _mapper;
        private GeepDbContext _db;
        private ICrudInteger<BeneficiaryVm> _beneficiaryQuery;

        public BeneficiaryManagement(GeepDbContext db, IRepo<Beneficiary> repo, IMapper mapper, ICrudInteger<BeneficiaryVm> beneficiaryQuery)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
            _beneficiaryQuery = beneficiaryQuery;
        }

        public async Task<List<BeneficiaryVm>> GetBeneficiaryByAssociationId(int id)
        {
            return _mapper.Map<List<BeneficiaryVm>>(await _repo.GetAllById($"{nameof(Association)},{nameof(Models.Core.Agent)}", x => x.AssociationId.Equals(id)));
        }

        public async Task<List<BeneficiaryVm>> GetBeneficiaryByAgentId(int id)
        {
            return _mapper.Map<List<BeneficiaryVm>>(await _repo.GetAllById($"{nameof(Association)},{nameof(Models.Core.Agent)}", x => x.AgentId.Equals(id)));

        }



        public async Task<AgentVm> GetAgentByReferenceId(string id)
        {
            return _mapper.Map<AgentVm>(await _db.Agents.AsNoTracking().FirstOrDefaultAsync(x => x.ReferenceId.Equals(id)));

        }
        public async Task<AgentVm> AddAgent(AgentVm vm)
        {
            try
            {
                var model = _mapper.Map<Models.Core.Agent>(vm);
                _db.Agents.Add(model);
                await _db.SaveChangesAsync();
                return _mapper.Map<AgentVm>(model);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<AssociationVm> GetAssociationByAssociationName(string groupName)
        {
            return _mapper.Map<AssociationVm>(await _db.Associations.AsNoTracking().FirstOrDefaultAsync(x => x.AssociationName.ToUpper().Trim().Equals(groupName.ToUpper().Trim())));
        }

        public async Task PushRecordsToWhiteList()
        {
            var beneficiaries = _mapper.Map<List<BeneficiaryVm>>(await _db.Beneficiaries.Include(x=>x.Agent).Include(x=>x.Association).AsNoTracking().Where(x=>x.IsApprovedByWhiteList.Equals(false)).ToListAsync());
            int totalRecordPushed = 0;
            int approvedRecords = 0;
            int rejectedRecords = 0;
            foreach (var beneficiary in beneficiaries)
            {

                var response = await BOIHelper.PusheToWhiteList(beneficiary);
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
    }
}

