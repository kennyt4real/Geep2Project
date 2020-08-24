using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.UserVm
{
    public class UserRoleVm
    {
        public List<string> Roles { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
