using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels
{
    public class PortalResponseVm
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("data")]
        public bool Data { get; set; }
    }
}
