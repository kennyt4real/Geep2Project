using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class ClusterLocationVm : AuditVm
    {
        public int ClusterLocationId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public int ReferenceId { get; set; }
    }
}
