using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models.Core
{
    public class AssociationBeneficiary : Audit
    {
        public int AssociationBeneficiaryId { get; set; }
        public int AssociationId { get; set; }
        public int BeneficiaryId { get; set; }
        public Association Association { get; set; }
        public Beneficiary Beneficiary { get; set; }
    }
}
