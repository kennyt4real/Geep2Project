using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class DocumentVm : AuditVm
    {
        public int DocumentId { get; set; }
        [JsonProperty("filetype")]
        public string FileType { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }
    }
}
