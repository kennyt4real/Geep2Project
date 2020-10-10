using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Models.Core
{
    public class Document : Audit
    {
        public int DocumentId { get; set; }
        public int AssociationId { get; set; }
        public string FileType { get; set; }
        public string File { get; set; }
    }
}
