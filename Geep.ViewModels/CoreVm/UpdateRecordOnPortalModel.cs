using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class UpdateRecordOnPortalModel
    {
        [JsonPropertyName("id")]
        public int ReferenceId { get; set; }

        [JsonPropertyName("pushed_to_whitelist")]
        public bool PushedToWhiteList { get; set; }

        [JsonPropertyName("is_approved_by_whitelist")]
        public bool IsApprovedByWhiteList { get; set; }

        [JsonPropertyName("rejection_reason")]
        public string RejectionReason { get; set; }

        [JsonPropertyName("reference_key")]
        public string ReferenceKey { get; set; }
    }
}
