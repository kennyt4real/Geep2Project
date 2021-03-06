﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class BeneficiaryVm : AuditVm
    {
        public int BeneficiaryId { get; set; }
        public int ReferenceId { get; set; }
        public int ClusterLocationId { get; set; }
        public int TreadeTypeId { get; set; }
        public int TradeSubType { get; set; }
        public int AgentId { get; set; }
        public int CurrentProgramId { get; set; }
        public int? AssociationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        public string BVN { get; set; }
        public string HomeAddress { get; set; }
        public string CurrendBankId { get; set; }
        public string AccountNumber { get; set; }
        public string GPS { get; set; }
        public string FacialPicture { get; set; }
        public string Picture { get; set; }
        public string SmileIdZip { get; set; }
        public string Disability { get; set; }
        public string SmileReference { get; set; }
        public string DateEnumerated { get; set; }
        public string NextOfKinAddress { get; set; }
        public string NextOfKinPhone { get; set; }
        public string GuarantorFirstName { get; set; }
        public string GuarantoLastName { get; set; }
        public string GuarantorFirstPhone { get; set; }
        public string IdCardNumber { get; set; }
        public string NextOfKinName { get; set; }
        public string GeopoliticalId { get; set; }
    }
}
