using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geep.DataAccess;
using Geep.DomainLayer.CustomAbstrations;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels.UserVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Geep.Web.Controllers
{
    [Authorize]

    public class UserManagementController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IPasswordGenerator _pwdGen;
        private IEmailSender _emailService;

        public UserManagementController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IPasswordGenerator pwdGen, IEmailSender emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _pwdGen = pwdGen;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleString = roles.Select(s => s.Name).ToList();
            var selectRole = roleString.Select(s => new { Name = s.ToUpper() }).ToList();

            ViewData["RoleName"] = new MultiSelectList(selectRole, "Name", "Name");
           
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(AddUserToRoleVm vm)
        {
            string message = string.Empty;
            string errorMessages = string.Empty;
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = vm.Email,
                    Email = vm.Email,
                    FirstName = vm.FirstName,
                    LastName =vm.LastName,
                    EmailConfirmed = true,
                };
                string _tempPassword = _pwdGen.GeneratePassword(true, true, true, true, false, 7);

                var result = await _userManager.CreateAsync(newUser, _tempPassword);
                if (result.Succeeded)
                {
                    await _emailService.SendEmailAsync(vm.Email, "GEEP Dashboard",
                    $"A user account has been created with your email address on the GEEP Dashbpoard." +
                    $" and the password to the account is  <b>{_tempPassword}</b>. Click this link https://geepdashboard.azurewebsites.net to login ");
                }
              

                //var user = await _userManager.FindByEmailAsync(vm.Email);
                message = $"{vm.FullName} has been assigned to ";
                foreach (var role in vm.RoleName)
                {
                    var roleResult = await _userManager.AddToRoleAsync(newUser, role);

                    if (roleResult.Succeeded)
                    {
                        message += $"{role} ";
                    }
                    else
                    {
                        errorMessages = string.Join("; ", ModelState.Values
                                                     .SelectMany(x => x.Errors)
                                                     .Select(x => x.ErrorMessage));
                        message = $"Something went wrong {errorMessages}";
                        return Json(new { status = false, message });

                    }
                }
                message += " Successfully";
                return Json(new { status = true, message });

            }
            errorMessages = string.Join("; ", ModelState.Values
                                                   .SelectMany(x => x.Errors)
                                                   .Select(x => x.ErrorMessage));

            message = $"Something went wrong {errorMessages}";
            return Json(new { status = false, message });
        }

        [HttpGet]
        public async Task<IActionResult> UserRoles(string userId)
        {
            var appUser = await _userManager.FindByIdAsync(userId);
            var appUserRoles = await _userManager.GetRolesAsync(appUser);

            var vm = new UserRoleVm
            {
                UserId = userId,
                Roles = appUserRoles.ToList(),
                FullName = $"{appUser.FirstName} {appUser.LastName}" ,
                Email = appUser.Email
            };
            return PartialView(vm);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(string Email, string RoleName)
        {
            string message;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(RoleName))
            {
                message = $"Username or Role not selected";
                return Json(new { status = false, message });
            }

            var appUser = await _userManager.FindByEmailAsync(Email);
            var roleResult = await _userManager.RemoveFromRoleAsync(appUser, RoleName);
            if (roleResult.Succeeded)
            {
                message = $"{Email} has been removed from {RoleName} Successfully";
                return Json(new { status = true, message });
            }
            else
            {
                message = $"Error removing user role";
                foreach (var item in roleResult.Errors)
                {
                    message += $" {item}";
                }
                return Json(new { status = false, message });
            }
        }
    }
}