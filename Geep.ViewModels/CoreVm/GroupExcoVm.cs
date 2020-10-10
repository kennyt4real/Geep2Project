namespace Geep.ViewModels.CoreVm
{
    public class GroupExcoVm : AuditVm
    {
        public int GroupExcoId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string BVN { get; set; }
        public int StateId { get; set; }
        public int? LocalGovernmentAreaId { get; set; }
        public int AssociationId { get; set; }
    }

}
