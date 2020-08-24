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
using Microsoft.AspNetCore.Authorization;

namespace Geep.Web.Controllers
{
    [Authorize]

    public class LocalGovernmentAreasController : Controller
    {
        private ICrudInteger<LocalGovernmentAreaVm> _repo;
        private ICrudInteger<StateVm> _stateQuery;

        public LocalGovernmentAreasController(ICrudInteger<LocalGovernmentAreaVm> repo, ICrudInteger<StateVm> stateQuery)
        {
            _repo = repo;
            _stateQuery = stateQuery;
        }

        public IActionResult Index(int id)
        {
            ViewData["StateId"] = id;
            ViewData["StateName"] = _stateQuery.GetById(id).Result.StateName;
            return View();
        }

        public async Task<IActionResult> GetIndex(int id)
        {

            var data = await _repo.GetAllById(id);
            return Json(new { data });
        }

        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(LocalGovernmentAreaVm vm)
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
