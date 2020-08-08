using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AgentClusterLocationVm : AuditVm
    {
        public int AgentClusterLocationId { get; set; }
        public int AgentId { get; set; }
        public int ClusterLocationId { get; set; }
        public string AgentName { get; set; }
        public string AgentRefId { get; set; }
        public string ClusterName { get; set; }
        public string ClusterStateName { get; set; }
    }
}
