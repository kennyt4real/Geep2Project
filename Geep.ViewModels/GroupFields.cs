using Geep.ViewModels.CoreVm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Geep.ViewModels
{
    public class GroupFields
    {
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("group_id")]
        public string AssociationId { get; set; }

        [JsonPropertyName("asso_name")]
        public string AssociationName { get; set; }

        [JsonPropertyName("type")]
        public string AssociationType { get; set; }

        [JsonPropertyName("agentid")]
        public string AgentId { get; set; }

        [JsonPropertyName("super_agent")]
        public string SuperAgent { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("stateid")]
        public string StateId { get; set; }

        [JsonPropertyName("lgaid")]
        public string LGAId { get; set; }

        [JsonPropertyName("mou_status")]
        public string MOUStatus { get; set; }

        [JsonPropertyName("accreditation_status")]
        public string AccreditationStatus { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("members_count")]
        public string MembersCount { get; set; }

        public string TradeType { get; set; }

        [JsonProperty("trade_type")]
        public List<int> GroupTradeTypes { get; set; }

        public string EnumeratorId { get; set; }
        [JsonProperty("enumeratorid")]
        public List<int> EnumeratorIds { get; set; }

        [JsonPropertyName("beneficiary_count")]
        public string BeneficiaryCount { get; set; }

        [JsonPropertyName("leaders_name")]
        public string LeaderName { get; set; }

        [JsonPropertyName("leaders_phone")]
        public string LeaderPhoneNumber { get; set; }

        [JsonPropertyName("cacdoc")]
        public string CACDoc { get; set; }

        [JsonPropertyName("agent")]
        public AgentVm Agent { get; set; }

        [JsonPropertyName("group_leaders")]
        public List<ExcoInformation> GroupExcoInformations { get; set; }

        [JsonPropertyName("docs")]
        public DocumentVm[] Documents { get; set; }
    }

   
}
