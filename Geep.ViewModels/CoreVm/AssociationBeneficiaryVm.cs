using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AssociationBeneficiaryVm : AuditVm
    {
        public int AssociationBeneficiaryId { get; set; }
        public int AssociationId { get; set; }
        public int BeneficiaryId { get; set; }
    }
}
