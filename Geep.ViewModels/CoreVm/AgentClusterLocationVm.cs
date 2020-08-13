using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AgentClusterLocationVm : AuditVm
    {
        public int AgentClusterLocationId { get; set; }
        [Required]
        [DisplayName("Agent Name")]
        public int AgentId { get; set; }
        [Required]
        [DisplayName("Cluster Name")]
        public int ClusterLocationId { get; set; }
        [Required]
        [DisplayName("State")]
        public int StateId { get; set; }
        public string AgentName { get; set; }
        public string AgentRefId { get; set; }
        public string ClusterName { get; set; }
        public string ClusterStateName { get; set; }
    }
}
