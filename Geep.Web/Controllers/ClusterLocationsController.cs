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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Geep.Web.Controllers
{
    [Authorize]

    public class ClusterLocationsController : Controller
    {
        private ICrudInteger<ClusterLocationVm> _repo;
        private readonly ICrudInteger<StateVm> _stateQuery;
        private IWebHostEnvironment _environment;

        public ClusterLocationsController(ICrudInteger<ClusterLocationVm> repo, ICrudInteger<StateVm> stateQuery, IWebHostEnvironment environment)
        {
            _repo = repo;
            _stateQuery = stateQuery;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
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
        public PartialViewResult UploadClusterLocations()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> UploadClusterLocations(IFormFile excelFile)
        {
            //var file = Request.Form.Files[0];

            if (excelFile == null || excelFile.Length == 0)
            {
                return RedirectToAction("Index");
            }
            await _repo.ExcelImport(excelFile);

            return RedirectToAction("Index");

            //return Json(new { status = true, message = $"Cluster Locations Added Successfully {excelFile.FileName}" });

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
