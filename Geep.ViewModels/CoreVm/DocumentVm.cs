using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class DocumentVm : AuditVm
    {
        public int DocumentId { get; set; }
        public int AssociationId { get; set; }

        [JsonPropertyName("filetype")]
        public string FileType { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; }
    }
}
