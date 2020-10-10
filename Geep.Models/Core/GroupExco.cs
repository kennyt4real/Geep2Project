using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models.Core
{
    public class GroupExco : Audit
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
        public LocalGovernmentArea LocalGovernmentArea { get; set; }
        public Association Association { get; set; }
    }
}
