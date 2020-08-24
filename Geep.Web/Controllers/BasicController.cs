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
    [Authorize]

    public class BasicController : Controller
    {
        private readonly ICrudInteger<LocalGovernmentAreaVm> _query;
        private readonly ICrudInteger<AgentVm> _agentQuery;
        private readonly ICrudInteger<ClusterLocationVm> _clusterQuery;

        public BasicController(ICrudInteger<LocalGovernmentAreaVm> query, ICrudInteger<AgentVm> agentQuery, ICrudInteger<ClusterLocationVm> clusterQuery)
        {
            _query = query;
            _agentQuery = agentQuery;
            _clusterQuery = clusterQuery;
        }
        public async Task<IActionResult> GetLgaList(int stateId)
        {
            var data = await _query.GetAllById(stateId);

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