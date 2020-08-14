using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AgentVm : AuditVm
    {
        public int AgentId { get; set; }

        [StringLength(9)]
        [Required]
        [DisplayName("Reference ID")]
        [JsonProperty("agent_id")]
        public string ReferenceId { get; set; }

        [Required]
        [DisplayName("First Name")]
        [JsonProperty("agent_firstname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [JsonProperty("agent_lastname")]
        public string LastName { get; set; }

        [JsonProperty("agent_middlename")]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [JsonProperty("agnet_gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [JsonProperty("agent_dob")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty("agent_bvn")]
        [StringLength(11, MinimumLength = 11)]
        public string BVN { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        [JsonProperty("agent_phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Local Government")]
        [JsonProperty("agent_lgaid")]
        public int LocalGovtRefId { get; set; }

        [JsonProperty("agent_stateid")]
        [DisplayName("State")]
        public int StateId { get; set; }

        [JsonProperty("agent_home_address")]
        public string HomeAddress { get; set; }
        public string AgentFullName => $"{LastName} {FirstName}";
    }
}
