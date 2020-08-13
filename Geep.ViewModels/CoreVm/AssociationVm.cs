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
        public string AssociationRefId { get; set; }
        [Required]
        [DisplayName("Association Name")]
        public string AssociationName { get; set; }
        [Required]
        [DisplayName("Association Type")]
        public string AssiciationType { get; set; }
        [DisplayName("State")]
        public int StateId { get; set; }
        [Required]
        [DisplayName("Local Govt")]
        public int LocalGovernmentAreaId { get; set; }
        [Required]
        [DisplayName("Super Agent")]
        public string SuperAgent { get; set; }
        [Required]
        [DisplayName("Status")]
        public string AccreditationStstud { get; set; }
        [Required]
        [DisplayName("Group Phonenumber")]
        [StringLength(11, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string GroupPhoneNumber { get; set; }
        [Required]
        [DisplayName("Group Email")]
        public string GroupEmail { get; set; }

        public string AssociationLga { get; set; }

        public string AssociationState { get; set; }

    }
}
