using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels
{
    public abstract class AuditVm
    {
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
