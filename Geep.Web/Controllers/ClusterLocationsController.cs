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
using ClosedXML.Excel;
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

        public IActionResult Import()
        {
            IFormFile file = Request.Form.Files[0];
            string wwwPath = this._environment.WebRootPath;
            string contentPath = this._environment.ContentRootPath;

            string path = Path.Combine(this._environment.WebRootPath, "Upload");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var clusterLocationList = new List<ClusterLocationVm>();
            using (var excelWorkbook = new XLWorkbook(Path.GetFileName(file.FileName)))
            {
                var ws1 = excelWorkbook.Worksheet(1);
                int rowCount = ws1.RowsUsed().Count();
                int colCount = ws1.ColumnsUsed().Count();


                for (int i = 2; i <= rowCount; i++)
                {
                    for (int j = 1; j <= 1; j++)
                    {
                        var clusterLocation = new ClusterLocationVm
                        {
                            ReferenceId = int.Parse(ws1.Cell(i, 1).Value.ToString()),
                            Name = ws1.Cell(i, 2).Value.ToString(),
                            StateId = int.Parse(ws1.Cell(i, 5).Value.ToString()),
                           
                        };
                        clusterLocationList.Add(clusterLocation);
                    }
                }
                return View();
            }
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
