using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geep.Web.Controllers
{
    [Route("[controller]")]
    public class BasicController : Controller
    {
        private readonly ICrudInteger<LocalGovernmentAreaVm> _lgaQuery;
        private readonly ICrudInteger<AgentVm> _agentQuery;
        private readonly ICrudInteger<ClusterLocationVm> _clusterQuery;
        private readonly ICrudInteger<StateVm> _stateQuery;

        public BasicController(ICrudInteger<LocalGovernmentAreaVm> lgaQuery, ICrudInteger<AgentVm> agentQuery, 
                                ICrudInteger<ClusterLocationVm> clusterQuery, ICrudInteger<StateVm> stateQuery)
        {
            _lgaQuery = lgaQuery;
            _agentQuery = agentQuery;
            _clusterQuery = clusterQuery;
            _stateQuery = stateQuery;
        }
        [HttpGet(nameof(GetStateList))]
        public async Task<IActionResult> GetStateList()
        {
            return Json(JsonConvert.SerializeObject(await _stateQuery.GetAll()));
        }

        [HttpGet(nameof(GetLgaList))]
        public async Task<IActionResult> GetLgaList(int stateId)
        {
            var data = await _lgaQuery.GetAllById(stateId);

            return Json(JsonConvert.SerializeObject(data));
        }
        public async Task<IActionResult> GetClusterList(int stateId)
        {
            var data = await _clusterQuery.GetAllById(stateId);

            return Json(JsonConvert.SerializeObject(data));
        }
        public async Task<IActionResult> GetAgentList(int stateId)
        {
            var data = await _agentQuery.GetAllById(stateId);

            return Json(JsonConvert.SerializeObject(data));
        }
    }
}