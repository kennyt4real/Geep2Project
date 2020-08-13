﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geep.Models.Core
{
    public class Agent : Audit
    {
        public int AgentId { get; set; }
        [UniqueKey(groupId: "1", order: 0)]
        public string ReferenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BVN { get; set; }
        public string PhoneNumber { get; set; }
        public int LocalGovtRefId { get; set; }
        public string HomeAddress { get; set; }
        public string AgentFullName => LastName + " " + FirstName;
        public ICollection<ClusterLocation> ClusterLocations { get; set; }
    }
}