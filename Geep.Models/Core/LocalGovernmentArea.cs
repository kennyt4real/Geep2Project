namespace Geep.Models.Core
{
    public class LocalGovernmentArea : Audit
    {
        public int LocalGovernmentAreaId { get; set; }
        public int StateId { get; set; }
        public string LgaName { get; set; }
        [UniqueKey(groupId: "1", order: 0)]

        public int ReferenceId { get; set; }
        public State State { get; set; }
    }
}