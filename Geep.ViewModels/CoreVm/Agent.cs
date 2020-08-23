using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class Agent
    {
        [JsonPropertyName("agent_id")]
        public string AgentId { get; set; }

        [JsonPropertyName("agent_firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("agent_lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("agent_middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("agent_gender")]
        public string Gender { get; set; }

        [JsonPropertyName("agent_dob")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("agent_bvn")]
        public string BVN { get; set; }

        [JsonPropertyName("agent_phone")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("agent_stateid")]
        public int StateId { get; set; }

        [JsonPropertyName("agent_lgaid")]
        public int LGAId { get; set; }

        [JsonPropertyName("agent_home_address")]
        public string Address { get; set; }
    }
}