using System.ComponentModel.DataAnnotations;

namespace Geep.Models.Core
{
    public class Association : Audit
    {
        public int AssociationId { get; set; }
        [UniqueKey(groupId: "1", order: 0)]
        [StringLength(12)]
        public string AssociationRefId { get; set; }
        public string AssociationName { get; set; }
        public string AssiciationType { get; set; }
        public int LocalGovernmentAreaId { get; set; }
        public string SuperAgent { get; set; }
        public string AccreditationStstud { get; set; }
        public string GroupPhoneNumber { get; set; }
        public string GroupEmail { get; set; }
        public LocalGovernmentArea LocalGovernmentArea { get; set; }
    }
}