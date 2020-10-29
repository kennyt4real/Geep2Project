using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class CreateBeneficiary
    {
        [JsonPropertyName("id")]
        public int ReferenceId { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastNmae { get; set; }

        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("dob")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("cluster_location")]
        public int ClusterLocationId { get; set; }

        [JsonPropertyName("bvn")]
        public string BVN { get; set; }

        [JsonPropertyName("association_id")]
        public int? AssociationId { get; set; }

        [JsonPropertyName("tradetypeid")]
        public int TradeTypeId { get; set; }

        [JsonPropertyName("trade_subtype")]
        public int TradeSubType { get; set; }

        [JsonPropertyName("stateid")]
        public int StateId { get; set; }

        [JsonPropertyName("lgaid")]
        public int LGAId { get; set; }

        [JsonPropertyName("home_address")]
        public string HomeAddress { get; set; }

        [JsonPropertyName("current_bank_id")]
        public string CurrentBankId { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("gps")]
        public string GPS { get; set; }

        [JsonPropertyName("facial_picture")]
        public string FacialPicture { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }

        [JsonPropertyName("smileid_zip")]
        public string SmilIdZip { get; set; }

        [JsonPropertyName("disability")]
        public string Disability { get; set; }

        [JsonPropertyName("agent")]
        public AgentVm Agent { get; set; }

        [JsonPropertyName("groupname")]
        public string GroupName { get; set; }

        [JsonPropertyName("smile_reference")]
        public string SmileReference { get; set; }

        [JsonPropertyName("date_enumerated")]
        public string DateEnumerated { get; set; }

        [JsonPropertyName("current_program_id")]
        public int CurrentProgramId { get; set; }

        [JsonPropertyName("next_of_kin_address")]
        public string NextOfKinAddress { get; set; }

        [JsonPropertyName("next_of_kin_phone")]
        public string NextOfKinPhoneNumber { get; set; }

        [JsonPropertyName("guarantors_fname_1")]
        public string GuarantorFirstName { get; set; }

        [JsonPropertyName("guarantors_lname_1")]
        public string GuarantorsLastName { get; set; }

        [JsonPropertyName("guarantors_lphone_1")]
        public string GuarantorsPhoneNumber { get; set; }

        [JsonPropertyName("id_card_number")]
        public string IdCardNumber { get; set; }

        [JsonPropertyName("next_of_kin_name")]
        public string NextOfKinName { get; set; }

        [JsonPropertyName("geopolitical_id")]
        public string GeopoliticalId { get; set; }

        [JsonPropertyName("number_of_employees")]
        public int NumberOfEmployees { get; set; }

        [JsonPropertyName("total_value_of_current_business")]
        public decimal TotalValueOfCurrentBusiness { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
    }
}
