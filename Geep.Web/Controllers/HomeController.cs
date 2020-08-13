using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Geep.Web.Models;
using Geep.ViewModels.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Geep.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CustomDashboard()
        {
            if (User.IsInRole(RoleName.QualityControl))
            {
                return RedirectToAction("AdminDashboard", "Home");
            }

            else if (User.IsInRole(RoleName.Admin))
            {
                return RedirectToAction("AdminDashboard", "Home");
            }
            else if (User.IsInRole(RoleName.SuperAdmin))
            {
                return RedirectToAction("AdminDashboard", "Home");
            }
            return View("Index");
        }

    }
}
