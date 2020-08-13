using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class StateVm :AuditVm
    {
        public int StateId { get; set; }
        [Required]
        [DisplayName("State Name")]
        public string StateName { get; set; }
        [Required]
        [DisplayName("Reference Number")]
        public int ReferenceId { get; set; }
    }
}
