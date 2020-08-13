using Geep.DataAccess;
using Geep.DataAccess.Context;
using Geep.DomainLayer.GeneralAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Geep.Web.Services
{
    public class UserContext : IUserContext
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private static readonly HttpContextAccessor Accessor = new HttpContextAccessor();
        public GeepDbContext _db { get; }
        public UserContext(GeepDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public string GetUserId()
        {
            return Accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetUserEmail()
        {
            return Accessor.HttpContext.User.Identity.Name;
        }

        public bool IsInRole(string role)
        {
            return Accessor.HttpContext.User.IsInRole(role);
        }


        public async Task<List<string>> GetUserRoles()
        {
            if (Accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var appUser = await _userManager.FindByIdAsync(GetUserId());

                var roleNames = await _userManager.GetRolesAsync(appUser);
                return roleNames.ToList();
            }
            return new List<string>();

        }

    }
}
