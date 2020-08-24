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

    public class ClusterLocationsController : Controller
    {
        private ICrudInteger<ClusterLocationVm> _repo;
        private readonly ICrudInteger<StateVm> _stateQuery;

        public ClusterLocationsController(ICrudInteger<ClusterLocationVm> repo, ICrudInteger<StateVm> stateQuery)
        {
            _repo = repo;
            _stateQuery = stateQuery;
        }

        public async  Task<IActionResult> Index()
        {
            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName");

            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var data = await _repo.GetAll();
            return Json(new { data });
        }

        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName", model?.StateId);

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ClusterLocationVm vm)
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
