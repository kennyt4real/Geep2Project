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
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels.CoreVm;

namespace Geep.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrudInteger<BeneficiaryVm> _benQuery;
        private readonly ICrudInteger<AgentVm> _agentQuery;

        public HomeController(ILogger<HomeController> logger, ICrudInteger<BeneficiaryVm> benQuery, ICrudInteger<AgentVm> agentQuery)
        {
            _logger = logger;
            _benQuery = benQuery;
            _agentQuery = agentQuery;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(AdminDashboard));
        }
        public async Task<IActionResult> AdminDashboard()
        {
            var beneficiaries = await _benQuery.GetAll();
            var agents = await _agentQuery.GetAll();
            ViewBag.BeneficiaryCount = beneficiaries.Count();
            ViewBag.ApprovedRecords = beneficiaries.Where(x=>x.IsApprovedByWhiteList.Equals(true)).Count();
            ViewBag.RejectedRecords = beneficiaries.Where(x=>x.PushedToWhiteList.Equals(true) && x.IsApprovedByWhiteList.Equals(false)).Count();
            ViewBag.AgentsCount = agents.Count();
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
