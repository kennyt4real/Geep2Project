using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Geep.ViewModels.CoreVm
{
    public class AgentVm : AuditVm
    {
        public int AgentId { get; set; }
        [StringLength(9)]
        public string ReferenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string BVN { get; set; }
        public string PhoneNumber { get; set; }
        public int LocalGovtRefId { get; set; }
        public string HomeAddress { get; set; }
    }
}
