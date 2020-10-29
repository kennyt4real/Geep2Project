using System.Collections.Generic;

namespace Geep.Models.Core
{
    public class ClusterLocation : Audit
    {
        public int ClusterLocationId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        [UniqueKey]
        public int ReferenceId { get; set; }
        public State State { get; set; }
    }
}