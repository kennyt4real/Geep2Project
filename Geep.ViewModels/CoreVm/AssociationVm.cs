using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AssociationVm : AuditVm
    {
        [JsonProperty("group_id")]
        public int AssociationId { get; set; }

        [StringLength(12)]
        [Required]
        [DisplayName("Association Ref ID")]
        [JsonProperty("association_id")]
        public string AssociationRefId { get; set; }

        [Required]
        [DisplayName("Association Name")]
        [JsonProperty("asso_name")]
        public string AssociationName { get; set; }

        [Required]
        [DisplayName("Association Type")]
        [JsonProperty("type")]
        public string AssociationType { get; set; }

        [Required]
        [DisplayName("State")]
        public int StateId { get; set; }

        public int DocumentId { get; set; }

        [Required]
        [DisplayName("Local Govt")]
        public int LocalGovernmentAreaId { get; set; }

        [Required]
        [DisplayName("Super Agent")]
        [JsonProperty("super_agent")]
        public string SuperAgent { get; set; }
        [Required]
        [DisplayName("Status")]
        [JsonProperty("accreditation_status")]
        public string AccreditationStatus { get; set; }

        [Required]
        [DisplayName("Group Phonenumber")]
        [StringLength(11, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        [JsonProperty("group_phone")]
        public string GroupPhoneNumber { get; set; }

        [Required]
        [DisplayName("Group Email")]
        [JsonProperty("group_email")]
        public string GroupEmail { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("mou_status")]

        public string MOUStatus { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("agentid")]
        public string AgentId { get; set; }
        [JsonProperty("members_count")]
        public string MemberCount { get; set; }
        public string TradeType { get; set; }
        
        public string EnumeratorId { get; set; }
      
        [JsonProperty("enumeratorid")]
        public string BeneficiaryCount { get; set; }
        [JsonProperty("leaders_name")]
        public string LeaderName { get; set; }
        [JsonProperty("leaders_phone")]
        public string LeaderPhoneNumber { get; set; }
        public string CACDoc { get; set; }

        [JsonProperty("docs")]

        public DocumentVm Document { get; set; }
        [JsonProperty("lgaid")]
        public string AssociationLga { get; set; }
        [JsonProperty("stateid")]
        public string AssociationState { get; set; }

        public List<BeneficiaryVm> Beneficiaries { get; set; }
        public AgentVm Agent { get; set; }
        public bool PushedToWhiteList { get; set; }
        public bool IsApprovedByWhiteList { get; set; }
        public string RejectionReason { get; set; }
        public string ReferenceKey { get; set; }
        public bool IsUpdatedOnPortal { get; set; }



    }
}
