﻿using Geep.ViewModels.CoreVm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels
{
    public class TeamUsersPortalResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("error_message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public List<GeepAgent> Agents { get; set; }
    }

    public class GeepAgent
    {
        [JsonProperty("userId")]
        public int AgentId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }



    //public class PortalAgent
    //{
    //    public string first_name { get; set; }
    //    public string last_name { get; set; }
    //    public string gender { get; set; }
    //    public object id_string { get; set; }
    //    public string photo_string { get; set; }
    //    public string address { get; set; }
    //    public object primary_location { get; set; }
    //    public object secondary_location { get; set; }
    //    public int team_id { get; set; }
    //    public object project_users { get; set; }
    //    public object form_users { get; set; }
    //    public string email { get; set; }
    //    public string application_user_id { get; set; }
    //    public int userRole { get; set; }
    //    public int accountNumber { get; set; }
    //    public object bankName { get; set; }
    //    public string phoneNumber { get; set; }
    //    public string country { get; set; }
    //    public string state { get; set; }
    //    public bool is_active { get; set; }
    //    public string team_name { get; set; }
    //    public object bvn_number { get; set; }
    //    public bool teamIsActive { get; set; }
    //    public bool teamIsDeleted { get; set; }
    //    public int id { get; set; }
    //    public object updatedBy { get; set; }
    //    public DateTime created_at { get; set; }
    //    public object utcModifiedAt { get; set; }
    //    public object utcDeletedAt { get; set; }
    //    public bool isDeleted { get; set; }
    //}

    public class PortalAgent
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        [JsonProperty("data")]
        public AgentVm Agent { get; set; }
    }

    public class AddUserToClusterModel
    {
        public string Emails { get; set; }
        public string Clusters { get; set; }
    }

    //public int AgentId { get; set; }
    //[UniqueKey(groupId: "1", order: 0)]
    //public string ReferenceId { get; set; }
    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    //public string MiddleName { get; set; }
    //public string Gender { get; set; }
    //public DateTime? DateOfBirth { get; set; }
    //public string BVN { get; set; }
    //public string PhoneNumber { get; set; }
    //public int LocalGovtRefId { get; set; }
    //public string HomeAddress { get; set; }
}
