using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class AssociationVm : AuditVm
    {
        public int AssociationId { get; set; }
        [JsonPropertyName("group_id")]
        public int ReferenceId { get; set; }

        [JsonPropertyName("asso_name")]
        public string AssociationName { get; set; }

        [JsonPropertyName("type")]
        public string AssociationType { get; set; }

        [JsonPropertyName("stateid")]
        public int StateId { get; set; }

        [JsonPropertyName("lgaid")]
        public int LocalGovernmentAreaId { get; set; }

        [JsonPropertyName("super_agent")]
        public string SuperAgent { get; set; }       
             
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        public string MOUStatus { get; set; }
        [JsonPropertyName("channel")]
        public string Channel { get; set; }
        [JsonPropertyName("agentid")]
        public string AgentId { get; set; }
        [JsonPropertyName("members_count")]
        public string MemberCount { get; set; }
        [JsonPropertyName("trade_type")]
        public string TradeType { get; set; }
        [JsonPropertyName("enumeratorid")]
        public string EnumeratorId { get; set; }      
        public string BeneficiaryCount { get; set; }
        [JsonPropertyName("leaders_name")]
        public string LeaderName { get; set; }
        [JsonPropertyName("leaders_phone")]
        public string LeaderPhoneNumber { get; set; }
        [JsonPropertyName("docs")]
        public List<DocumentVm> Documents { get; set; }
        [JsonPropertyName("group_leaders")]
        public List<CreateBeneficiary> Beneficiaries { get; set; }
        [JsonPropertyName("agent")]
        public AgentVm Agent { get; set; }
        public bool PushedToWhiteList { get; set; }
        public bool IsApprovedByWhiteList { get; set; }
        public string RejectionReason { get; set; }
        public string ReferenceKey { get; set; }
        public bool IsUpdatedOnPortal { get; set; }
        public string AssociationState { get; set; }
        public string AssociationLga { get; set; }
        public string AccreditationStatus
        {
            get
            {
                if (IsApprovedByWhiteList)
                    return "Accredited";
                if (PushedToWhiteList)
                    return "Rejected";
                return "Submitted";
            }
        }
    }
}
