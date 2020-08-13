using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.ViewModels.Constants
{
    public static class RoleName
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string QualityControl = "QualityControl";

        public static List<string> GetRoleList()
        {
            return new List<string>
            {
                Admin, SuperAdmin, QualityControl
            };
        }
    }
}
