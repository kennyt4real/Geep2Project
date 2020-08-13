using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models.Core
{
    public class AgentClusterLocation : Audit
    {
        public int AgentClusterLocationId { get; set; }
        public int AgentId { get; set; }
        public int ClusterLocationId { get; set; }

        public Agent Agent { get; set; }
        public ClusterLocation ClusterLocation { get; set; }

    }
}
