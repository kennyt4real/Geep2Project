using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.DataAccess.Context
{
    public static class DatabaseSeed
    {
        public static void PopulateUserRole(ModelBuilder builder)
        {
            // any guid
            string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e513";
            string SUPERADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e613";
            string QUALITYCONTROL = "a18be9c0-aak5-4af8-bd17-00bd934nfn13";

            // any guid, but nothing is against to use the same one
            string ROLE_ID = ADMIN_ID;
            string SUPERROLE_ID = SUPERADMIN_ID;
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = ROLE_ID, Name = "Admin", NormalizedName = "Admin" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = SUPERROLE_ID, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = QUALITYCONTROL, Name = "QualityControl", NormalizedName = "QUALITYCONTROL" });


            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Admin@geepproject.com",
                Email = "Admin@geepproject.com",
                NormalizedUserName = "ADMIN@GEEPPROJECT.COM",
                NormalizedEmail = "ADMIN@GEEPPROJECT.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admingeep@12345.."),
                SecurityStamp = string.Empty
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = SUPERADMIN_ID,
                UserName = "SuperAdmin@geepproject.com",
                Email = "SuperAdmin@geepproject.com",
                NormalizedUserName = "SUPERADMIN@GEEPPROJECT.COM",
                NormalizedEmail = "SUPERADMIN@GEEPPROJECT.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "supergeepadmin@12345"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = SUPERROLE_ID,
                UserId = SUPERADMIN_ID
            });
        }


    }
}
