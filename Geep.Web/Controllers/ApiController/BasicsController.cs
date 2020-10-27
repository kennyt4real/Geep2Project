using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geep.Web.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicsController : ControllerBase
    {
        private readonly ICrudInteger<LocalGovernmentAreaVm> _lgaQuery;
        private readonly ICrudInteger<StateVm> _stateQuery;

        public BasicsController(ICrudInteger<LocalGovernmentAreaVm> lgaQuery, ICrudInteger<StateVm> stateQuery)
        {
            _lgaQuery = lgaQuery;
            _stateQuery = stateQuery;
        }
        [HttpGet(nameof(GetStateList))]
        public async Task<IActionResult> GetStateList()
        {
            var data = await _stateQuery.GetAll();
            if(data.Any())
                return Ok(data);
            return BadRequest("Something went wrong");
        }
        [HttpGet(nameof(GetLgaList))]
        public async Task<IActionResult> GetLgaList(int stateId)
        {
            var data = await _lgaQuery.GetAllById(stateId);
            if(data.Any())
                return Ok(data);
            return BadRequest("No lga found");
        }
    }
}
