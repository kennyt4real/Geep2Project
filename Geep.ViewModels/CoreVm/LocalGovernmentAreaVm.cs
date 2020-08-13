using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class LocalGovernmentAreaVm : AuditVm
    {
        public int LocalGovernmentAreaId { get; set; }
        public int StateId { get; set; }
        [Required]
        [DisplayName("Local Govt Name")]
        public string LgaName { get; set; }
        [Required]
        [DisplayName("Reference ID")]
        public int ReferenceId { get; set; }
        [DisplayName("State Name")]
        public string StateName { get; set; }
    }
}
