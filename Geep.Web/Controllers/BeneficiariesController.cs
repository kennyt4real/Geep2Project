using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geep.DataAccess.Context;
using Geep.Models.Core;
using Geep.ViewModels.CoreVm;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.DomainLayer.CustomAbstrations;

namespace Geep.Web.Controllers
{
    public class BeneficiariesController : Controller
    {
        private ICrudInteger<BeneficiaryVm> _repo;
        private IBeneficiaryManagement _beneficiaryQuery;
        private ICrudInteger<AgentVm> _agentQuery;
        private ICrudInteger<AssociationVm> _associationQuery;

        public BeneficiariesController(ICrudInteger<BeneficiaryVm> repo, IBeneficiaryManagement beneficiaryQuery, 
                                                ICrudInteger<AgentVm> agentQuery, ICrudInteger<AssociationVm> associationQuery)
        {
            _repo = repo;
            _beneficiaryQuery = beneficiaryQuery;
            _agentQuery = agentQuery;
            _associationQuery = associationQuery;
        }

        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> GetIndex()
        {
            var data = await _repo.GetAll();
            return Json(new { data });
        }

        public async Task<IActionResult> AssociationMembers(int id)
        {
            var association = await _associationQuery.GetById(id);
            ViewData["AssociationId"] = id;
            ViewData["AssociationName"] = association.AssociationName;

            return View();
        }

        public async Task<IActionResult> GetAssociationMembers(int id)
        {
            var data = await _beneficiaryQuery.GetBeneficiaryByAssociationId(id);
            return Json(new { data });
        }


        public async Task<IActionResult> AgentRecords(int id)
        {
            var agent = await _agentQuery.GetById(id);
            ViewData["AgentId"] = id;
            ViewData["AgentName"] = agent.AgentFullName; 
            
            return View();
        }

        public async Task<IActionResult> GetAgentRecords(int id)
        {
            var data = await _beneficiaryQuery.GetBeneficiaryByAgentId(id);
            return Json(new { data });
        }

        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BeneficiaryVm vm)
        {
            if (ModelState.IsValid)
            {
                var response = await _repo.AddOrUpdate(vm);
                return Json(new { status = response.Status, message = response.Message });
            }
            string errorMessages = string.Join("; ", ModelState.Values
                                                    .SelectMany(x => x.Errors)
                                                    .Select(x => x.ErrorMessage));
            return Json(new { status = false, message = $"Oops.. {errorMessages}" });
        }

        [HttpPost, ActionName("Delete")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _repo.Delete(id);
            return Json(new { status = response.Status, message = response.Message });
        }
    }
}
