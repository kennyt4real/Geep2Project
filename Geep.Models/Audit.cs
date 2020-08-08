using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models
{
    public abstract class Audit 
    {
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
