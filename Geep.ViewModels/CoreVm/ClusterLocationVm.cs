using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class ClusterLocationVm : AuditVm
    {
        public int ClusterLocationId { get; set; }
        [Required]
        [DisplayName("State")]
        public int StateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Reference ID")]
        public int ReferenceId { get; set; }
        public string StateName { get; set; }
        public StateVm State { get; set; }
    }
}
