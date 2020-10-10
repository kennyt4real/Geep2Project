using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Geep.ViewModels
{
    public class ExcoInformation
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

       
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("bvn")]
        public string BVN { get; set; }

        [JsonPropertyName("state_id")]
        public int StateId { get; set; }

        [JsonPropertyName("lga_id")]
        public int LGAId { get; set; }
    }
}
