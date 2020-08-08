using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class LocalGovernmentAreaVm : AuditVm
    {
        public int LocalGovernmentAreaId { get; set; }
        public int StateId { get; set; }
        public string LgaName { get; set; }
        public int ReferenceId { get; set; }
        public string StateName { get; set; }
    }
}
