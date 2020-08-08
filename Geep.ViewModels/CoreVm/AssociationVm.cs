using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AssociationVm : AuditVm
    {
        public int AssociationId { get; set; }
        [StringLength(12)]
        public string AssociationRefId { get; set; }
        public string AssociationName { get; set; }
        public string AssiciationType { get; set; }
        public int LocalGovtId { get; set; }
        public string SuperAgent { get; set; }
        public string AccreditationStstud { get; set; }
        public string GroupPhoneNumber { get; set; }
        public string GroupEmail { get; set; }
    }
}
