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
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Hangfire.Processing;
using Hangfire;

namespace Geep.Web.Controllers
{
    [Authorize]
    public class BeneficiariesController : Controller
    {
        private ICrudInteger<BeneficiaryVm> _repo;
        private IEntitiesManagement _beneficiaryQuery;
        private ICrudInteger<AgentVm> _agentQuery;
        private ICrudInteger<AssociationVm> _associationQuery;
        private IMapper _mapper;
        private IBackgroundJobClient _background;
        private IUserContext _userContext;

        public BeneficiariesController(ICrudInteger<BeneficiaryVm> repo, IEntitiesManagement beneficiaryQuery, IMapper mapper, IBackgroundJobClient background,
                                                ICrudInteger<AgentVm> agentQuery, ICrudInteger<AssociationVm> associationQuery, IUserContext userContext)
        {
            _repo = repo;
            _beneficiaryQuery = beneficiaryQuery;
            _agentQuery = agentQuery;
            _associationQuery = associationQuery;
            _mapper = mapper;
            _background = background;
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> GetIndex()
        {
            var data = _mapper.Map<List<BeneFiciayListView>>(await _repo.GetAll());
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
            var data = _mapper.Map < List < BeneFiciayListView >>(await _beneficiaryQuery.GetBeneficiaryByAssociationId(id));
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
            var data = _mapper.Map<List<BeneFiciayListView>>(await _beneficiaryQuery.GetBeneficiaryByAgentId(id));
            return Json(new { data });
        }

        [HttpPost]
        public async Task<IActionResult> PushRecordsToWhiteList()
        {
            var user = _userContext.GetUserEmail();
            _background.Enqueue(() => _beneficiaryQuery.CreateGroupOnWhiteList(user));
            //await _beneficiaryQuery.PushBeneficiaryRecordsToWhiteList();
            return Json(new {status = true, message = "Pushing Records to WhiteList in progress...Will notify you via a mail at the end of the process!!!" });
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
