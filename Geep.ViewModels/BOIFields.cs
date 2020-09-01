using Geep.ViewModels.CoreVm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels
{
    public class BOIFields
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastNmae { get; set; }

        [JsonProperty("middlename")]
        public string MiddleName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("cluster_location")]
        public int ClusterLocation { get; set; }

        [JsonProperty("bvn")]
        public string BVN { get; set; }

        [JsonProperty("tradetypeid")]
        public int Tradetypeid { get; set; }

        [JsonProperty("trade_subtype")]
        public int TradeSubType { get; set; }

        [JsonProperty("stateid")]
        public int StateId { get; set; }

        [JsonProperty("home_address")]
        public string HomeAddress { get; set; }

        [JsonProperty("current_bank_id")]
        public string CurrentBankId { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("gps")]
        public string GPS { get; set; }

        [JsonProperty("facial_picture")]
        public string FacialPicture { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("smileid_zip")]
        public string SmilIdZip { get; set; }

        [JsonProperty("disability")]
        public string Disability { get; set; }

        [JsonProperty("agent")]
        public AgentVm[] Agent { get; set; }

        [JsonProperty("association")]
        public AssociationVm Association { get; set; }

        [JsonProperty("smile_reference")]
        public string SmileReference { get; set; }

        [JsonProperty("date_enumerated")]
        public string DateEnumerated { get; set; }

        [JsonProperty("current_program_id")]
        public int CurrentProgramId { get; set; }

        [JsonProperty("next_of_kin_address")]
        public string NextOfKinAddress { get; set; }

        [JsonProperty("next_of_kin_phone")]
        public string NextOfKinPhoneNumber { get; set; }

        [JsonProperty("guarantors_fname_1")]
        public string GuarantorFirstName { get; set; }

        [JsonProperty("guarantors_lname_1")]
        public string GuarantorsLastName { get; set; }

        [JsonProperty("guarantors_lphone_1")]
        public string GuarantorsPhoneNumber { get; set; }

        [JsonProperty("id_card_number")]
        public string IdCardNumber { get; set; }

        [JsonProperty("next_of_kin_name")]
        public string NextOfKinName { get; set; }

        [JsonProperty("geopolitical_id")]
        public string GeopoliticalId { get; set; }

        [JsonProperty("number_of_employees")]
        public int NumberOfEmployees { get; set; }

        [JsonProperty("total_value_of_current_business")]
        public decimal TotalValueOfCurrentBusiness { get; set; }
    }
}
