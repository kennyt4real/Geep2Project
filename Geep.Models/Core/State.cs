using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models.Core
{
    public class State : Audit
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        [UniqueKey(groupId: "1", order: 0)]
        public int ReferenceId { get; set; }
        public ICollection<LocalGovernmentArea> LocalGovernmentAreas { get; set; }


    }
}
