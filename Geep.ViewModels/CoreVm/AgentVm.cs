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
        public string ReferenceId { get; set; }

        [Required]
        [DisplayName("First Name")]
        [JsonPropertyName("agent_firstname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [JsonPropertyName("agent_lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("agent_middlename")]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("agent_gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("agent_dob")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("agent_bvn")]
        [StringLength(11, MinimumLength = 11)]
        public string BVN { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        [JsonPropertyName("agent_phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Local Government")]
        [JsonPropertyName("agent_lgaid")]
        public int LocalGovtRefId { get; set; }

        [JsonPropertyName("agent_stateid")]
        [DisplayName("State")]
        public int StateId { get; set; }

        [JsonPropertyName("agent_home_address")]
        public string HomeAddress { get; set; }
        public string AgentFullName => $"{LastName} {FirstName}";
    }
}
