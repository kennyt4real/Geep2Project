using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AssociationVm : AuditVm
    {
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
        [JsonProperty("association_type")]
        public string AssiciationType { get; set; }

        [DisplayName("State")]
        [JsonProperty("stateid")]
        public int StateId { get; set; }

        [Required]
        [DisplayName("Local Govt")]
        [JsonProperty("lgaid")]
        public int LocalGovernmentAreaId { get; set; }

        [Required]
        [DisplayName("Super Agent")]
        [JsonProperty("super_agent")]
        public string SuperAgent { get; set; }
        [Required]
        [DisplayName("Status")]
        [JsonProperty("accreditation_status")]
        public string AccreditationStstud { get; set; }

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

        public string AssociationLga { get; set; }

        public string AssociationState { get; set; }

    }
}
