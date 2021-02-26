using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerTestCase.Business.Abstract;
using CareerTestCase.Business.Services;
using CareerTestCase.Model;
using Microsoft.AspNetCore.Mvc;

namespace CareerTestCase.Controllers
{
    [ApiController]
    [Route("api/apply")]
    public class ApplyController : ControllerBase
    {
        private readonly IApplyService _applyService;
        private readonly IJobService _jobService;
        private readonly ICVService _cvService;
        public ApplyController(IApplyService applyService, IJobService jobService, ICVService cVService)
        {
            _applyService = applyService;
            _jobService = jobService;
            _cvService = cVService;
        }
        [HttpGet]
        [Route("ApplyByJobId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var apply = await _applyService.GetAppyByJobId(id);
            if (apply.Count() == 0)
                return NotFound("apply not found");
            return Ok(apply);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplyDTO apply)
        {
            if (apply == null)
                BadRequest("apply  can't be empty");
            var cv = await _cvService.GetByUserIdAsync(apply.UserId);
            if (cv == null) 
                return NotFound("You must have a cv to apply");
            var job = await _jobService.GetByIdAsync(apply.JopId);
            if (job==null)
                return NotFound("Apply for active jobs");
            bool res = await _applyService.AddAsync(apply);
            if (res)
                return Ok(apply);
            return BadRequest("User not registered");
        }
    }
}
