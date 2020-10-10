using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geep.DataAccess.Context;
using Geep.Models.Core;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels.CoreVm;
using static Geep.ViewModels.Constants.PopUp;
using Microsoft.AspNetCore.Authorization;
using Geep.DomainLayer.CustomAbstrations;

namespace Geep.Web.Controllers
{
    [Authorize]

    public class AssociationsController : Controller
    {
        private ICrudInteger<AssociationVm> _repo;
        private ICrudInteger<StateVm> _stateQuery;
        private IEntitiesManagement _beneficiaryQuery;

        public AssociationsController(ICrudInteger<AssociationVm> repo, ICrudInteger<StateVm> stateQuery, IEntitiesManagement beneficiaryQuery)
        {
            _repo = repo;
            _stateQuery = stateQuery;
            _beneficiaryQuery = beneficiaryQuery;
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

        [HttpPost]
        public async Task<IActionResult> PushGroupsToWhiteList()
        {
            await _beneficiaryQuery.CreateGroupOnWhiteList();
            return Json(new { status = true, message = "Pushing Records to WhiteList in progress...Will notify you via a mail at the end of the task!!!" });
        }

        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var status = from Status s in Enum.GetValues(typeof(Status))
                         select new { ID = s, Name = s.ToString() };


            ViewData["Status"] = new SelectList(status, "Name", "Name", model?.AccreditationStatus);

            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName", model?.StateId);


            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AssociationVm vm)
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
