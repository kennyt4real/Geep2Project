using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geep.Models.Core
{
    public class Association : Audit
    {
        public int AssociationId { get; set; }
        [UniqueKey]
        public int ReferenceId { get; set; }
        public string AssociationName { get; set; }
        public string AssociationType { get; set; }
        public int LocalGovernmentAreaId { get; set; }
        public string SuperAgent { get; set; }
        public string AccreditationStatus { get; set; }
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
        public LocalGovernmentArea LocalGovernmentArea { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Beneficiary> Beneficiaries { get; set; }
        public bool PushedToWhiteList { get; set; }
        public bool IsApprovedByWhiteList { get; set; }
        public string RejectionReason { get; set; }
        public string ReferenceKey { get; set; }
        public bool IsUpdatedOnPortal { get; set; }
    }
}