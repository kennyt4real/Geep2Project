using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class StateVm :AuditVm
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int ReferenceId { get; set; }
    }
}
