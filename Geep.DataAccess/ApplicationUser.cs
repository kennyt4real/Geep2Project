using Microsoft.AspNetCore.Identity;
using System;

namespace Geep.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsGoogleAuthenticatorEnabled { get; set; }
        public string GoogleAuthenticatorSecretKey { get; set; }
        public bool IsLogin { get; set; }
        public string PrimaryMail { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogOut { get; set; }
        public int NumberOfLogins { get; set; }
    }
}
