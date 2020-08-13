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
        public string ReferenceId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string BVN { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Local Government")]
        public int LocalGovtRefId { get; set; }
        [DisplayName("State")]
        public int StateId { get; set; }
        public string HomeAddress { get; set; }
        public string AgentFullName => $"{LastName} {FirstName}";
    }
}
