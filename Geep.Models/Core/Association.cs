﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geep.Models.Core
{
    public class Association : Audit
    {
        public int AssociationId { get; set; }
        [UniqueKey(groupId: "1", order: 0)]
        [StringLength(12)]
        public string AssociationRefId { get; set; }
        public int DocumentId { get; set; }
        public string AssociationName { get; set; }
        public string AssociationType { get; set; }
        public int LocalGovernmentAreaId { get; set; }
        public string SuperAgent { get; set; }
        public string AccreditationStatus { get; set; }
        public string GroupPhoneNumber { get; set; }
        public string GroupEmail { get; set; }
        public string ProductId { get; set; }
        public string Address { get; set; }
        public string MOUStatus { get; set; }
        public string Channel { get; set; }
        public string AgentId { get; set; }
        public string MembersCount { get; set; }
        public string TradeType { get; set; }
        public string EnumeratorId { get; set; }
        public string BeneficiaryCount { get; set; }
        public string LeaderName { get; set; }
        public string LeaderPhoneNumber { get; set; }
        public string CACDoc { get; set; }
        public LocalGovernmentArea LocalGovernmentArea { get; set; }
        public Document Document { get; set; }
        public ICollection<Beneficiary> Beneficiaries { get; set; }
        public bool PushedToWhiteList { get; set; }
        public bool IsApprovedByWhiteList { get; set; }
        public string RejectionReason { get; set; }
        public string ReferenceKey { get; set; }
        public bool IsUpdatedOnPortal { get; set; }
    }
}