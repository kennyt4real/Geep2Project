using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class BeneficiaryVm : AuditVm
    {
        public int BeneficiaryId { get; set; }

        [JsonProperty("id")]
        public int ReferenceId { get; set; }

        [JsonProperty("cluster_location")]
        public int ClusterLocationId { get; set; }

        [JsonProperty("tradetypeid")]
        public int TreadeTypeId { get; set; }

        [JsonProperty("trade_subtype")]
        public int TradeSubType { get; set; }

        public int AgentId { get; set; }

        [JsonProperty("cureent_program_id")]
        public int CurrentProgramId { get; set; }

        [JsonProperty("association_id")]
        public int? AssociationId { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("middlename")]
        public string MiddleName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [JsonProperty("phone")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [JsonProperty("bvn")]
        public string BVN { get; set; }

        [JsonProperty("home_address")]
        public string HomeAddress { get; set; }

        [JsonProperty("current_bank_id")]
        public string CurrendBankId { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("gps")]
        public string GPS { get; set; }

        [JsonProperty("facial_picture")]
        public string FacialPicture { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("smile_zip")]
        public string SmileIdZip { get; set; }

        [JsonProperty("disability")]
        public string Disability { get; set; }

        [JsonProperty("smile_reference")]
        public string SmileReference { get; set; }
        [JsonProperty("date_enumerated")]

        public string DateEnumerated { get; set; }
        [JsonProperty("next_of_kin_address")]

        public string NextOfKinAddress { get; set; }
        [JsonProperty("next_of_kin_phone")]

        public string NextOfKinPhone { get; set; }

        [JsonProperty("guarantors_fname_1")]
        public string GuarantorFirstName { get; set; }
        
        [JsonProperty("guarantors_lname_1")]
        public string GuarantoLastName { get; set; }

        [JsonProperty("gurantors_lphone_1")]        
        public string GuarantorFirstPhone { get; set; }

        [JsonProperty("id_card_number")]        
        public string IdCardNumber { get; set; }

        [JsonProperty("next_of_kin_name")]
        public string NextOfKinName { get; set; }

        [JsonProperty("geopolitical_id")]
        public string GeopoliticalId { get; set; }
        public string AgentName { get; set; }
        public string AgentRefId { get; set; }
        public string AssociationName { get; set; }
        public string BeneficiaryFullName => $"{LastName} {FirstName} {MiddleName}";
        public AgentVm  Agent { get; set; }
        public AssociationVm  Association { get; set; }

    }
}
