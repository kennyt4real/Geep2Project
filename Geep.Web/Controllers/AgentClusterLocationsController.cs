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

namespace Geep.Web.Controllers
{
    public class AgentClusterLocationsController : Controller
    {
        private ICrudInteger<AgentClusterLocationVm> _repo;
        private ICrudInteger<StateVm> _stateQuery;
        private readonly ICrudInteger<AgentVm> _agentQuery;
        private readonly ICrudInteger<ClusterLocationVm> _clusterQuery;

        public AgentClusterLocationsController(ICrudInteger<AgentClusterLocationVm> repo, ICrudInteger<StateVm> stateQuery, 
                                            ICrudInteger<AgentVm> agentQuery, ICrudInteger<ClusterLocationVm> clusterQuery )
        {
            _repo = repo;
            _stateQuery = stateQuery;
            _agentQuery = agentQuery;
            _clusterQuery = clusterQuery;
        }

        public async  Task<IActionResult> Index()
        {
            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName");
            ViewData["AgentId"] = new SelectList(await _agentQuery.GetAll(), "AgentId", "AgentFullName");
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
            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName",model?.StateId);
            ViewData["AgentId"] = new SelectList(await _agentQuery.GetAll(), "AgentId", "AgentFullName", model?.AgentId);
            //ViewData["ClusterLocationId"] = new SelectList(await _clusterQuery.GetAllById(model.StateId), "ClusterLocationId", "Name", model?.ClusterLocationId);

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AgentClusterLocationVm vm)
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
