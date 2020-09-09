using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class AgentVm : AuditVm
    {
        public int AgentId { get; set; }

        [StringLength(9)]
        [Required]
        [DisplayName("Reference ID")]
        [JsonPropertyName("agent_id")]
        [JsonProperty("agent_id")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Email")]
        [JsonPropertyName("agent_email")]
        [JsonProperty("agent_email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("First Name")]
        [JsonPropertyName("agent_firstname")]
        [JsonProperty("agent_firstname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [JsonPropertyName("agent_lastname")]
        [JsonProperty("agent_lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("agent_middlename")]
        [JsonProperty("agent_middlename")]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("agent_gender")]
        [JsonProperty("agent_gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("agent_dob")]
        [JsonProperty("agent_dob")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("agent_bvn")]
        [JsonProperty("agent_bvn")]
        [StringLength(11, MinimumLength = 11)]
        public string BVN { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        [JsonPropertyName("agent_phone")]
        [JsonProperty("agent_phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Local Government")]
        [JsonPropertyName("agent_lgaid")]
        [JsonProperty("agent_lgaid")]
        public int LocalGovtRefId { get; set; }

        [JsonPropertyName("agent_stateid")]
        [JsonProperty("agent_stateid")]
        [DisplayName("State")]
        public int StateId { get; set; }

        [JsonPropertyName("agent_home_address")]
        [JsonProperty("agent_home_address")]
        public string HomeAddress { get; set; }
        public string AgentFullName => $"{LastName} {FirstName}";
    }
}
