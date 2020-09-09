using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Geep.ViewModels.CoreVm
{
    public class BeneficiaryVm : AuditVm
    {
        public int BeneficiaryId { get; set; }

        [JsonPropertyName("id")]
        public int ReferenceId { get; set; }

        [JsonPropertyName("cluster_location")]
        public int ClusterLocationId { get; set; }

        [JsonPropertyName("lgaid")]
        public int LGAId { get; set; }

        [JsonPropertyName("tradetypeid")]
        public int TreadeTypeId { get; set; }

        [JsonPropertyName("trade_subtype")]
        public int TradeSubType { get; set; }

        public int AgentId { get; set; }

        [JsonPropertyName("cureent_program_id")]
        public int CurrentProgramId { get; set; }

        [JsonPropertyName("association_id")]
        public int? AssociationId { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("dob")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("phone")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("bvn")]
        public string BVN { get; set; }

        [JsonPropertyName("home_address")]
        public string HomeAddress { get; set; }

        [JsonPropertyName("current_bank_id")]
        public string CurrendBankId { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("gps")]
        public string GPS { get; set; }

        [JsonPropertyName("facial_picture")]
        public string FacialPicture { get; set; }

        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }

        [JsonPropertyName("smile_zip")]
        public string SmileIdZip { get; set; }

        [JsonPropertyName("disability")]
        public string Disability { get; set; }

        [JsonPropertyName("smile_reference")]
        public string SmileReference { get; set; }

        [JsonPropertyName("date_enumerated")]
        public string DateEnumerated { get; set; }

        [JsonPropertyName("next_of_kin_address")]
        public string NextOfKinAddress { get; set; }

        [JsonPropertyName("next_of_kin_phone")]
        public string NextOfKinPhone { get; set; }

        [JsonPropertyName("guarantors_fname_1")]
        public string GuarantorFirstName { get; set; }
        
        [JsonPropertyName("guarantors_lname_1")]
        public string GuarantoLastName { get; set; }

        [JsonPropertyName("gurantors_lphone_1")]        
        public string GuarantorFirstPhone { get; set; }

        [JsonPropertyName("id_card_number")]        
        public string IdCardNumber { get; set; }

        [JsonPropertyName("next_of_kin_name")]
        public string NextOfKinName { get; set; }

        [JsonPropertyName("geopolitical_id")]
        public string GeopoliticalId { get; set; }
        public string AgentName { get; set; }
        public string AgentRefId { get; set; }
        public string AssociationName { get; set; }

        [JsonPropertyName("number_of_employees")]
        public int NumberOfEmployees { get; set; }

        [JsonPropertyName("total_value_of_current_business")]
        public decimal TotalValueOfCurrentBusiness { get; set; }
        public string BeneficiaryFullName => $"{LastName} {FirstName} {MiddleName}";

        [JsonPropertyName("agent")]
        public AgentVm  Agent { get; set; }
        public AssociationVm  Association { get; set; }
        public ClusterLocationVm ClusterLocationVm { get; set; }
        public bool PushedToWhiteList { get; set; }
        public bool IsApprovedByWhiteList { get; set; }
        public string RejectionReason { get; set; }
        public string ReferenceKey { get; set; }
        public bool IsUpdatedOnPortal { get; set; }
        public string DisplayForIsPushedToWhiteList
        {
            get
            {
                if (PushedToWhiteList)
                    return "True";
                return "False";
            }
        }
        public string DisplayForIsApprovedByWhiteList
        {
            get
            {
                if (IsApprovedByWhiteList)
                    return "Approved";
                if(PushedToWhiteList)
                    return "Rejected";
                return "Submitted";
            }
        }
        public string DisplayForIsUpdatedOnPortal
        {
            get
            {
                if (IsUpdatedOnPortal)
                    return "True";
                return "False";
            }
        }
    }
}
