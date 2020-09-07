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
        [DisplayName("Cluster Name(s)")]
        public int[] ClusterLocationIds { get; set; }
        [Required]
        [DisplayName("State")]
        public int StateId { get; set; }

        [Required]
        [DisplayName("Email(s)")]
        public int[] AgentIds { get; set; }

        public int ClusterLocationId { get; set; }
        public int AgentId { get; set; }

        public string AgentEmail { get; set; }
        public string AgentName { get; set; }
        public string AgentRefId { get; set; }
        public string ClusterName { get; set; }
        public string ClusterStateName { get; set; }
    }
}
