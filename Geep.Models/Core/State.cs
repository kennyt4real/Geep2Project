using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models.Core
{
    public class State : Audit
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        [UniqueKey]
        public int ReferenceId { get; set; }
        public ICollection<LocalGovernmentArea> LocalGovernmentAreas { get; set; }

    }
}
