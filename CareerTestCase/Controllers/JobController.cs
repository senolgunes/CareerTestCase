using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerTestCase.Business.Abstract;
using CareerTestCase.Model;
using Microsoft.AspNetCore.Mvc;

namespace CareerTestCase.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : Controller
    {
        private  readonly IJobService _jobService;
        private readonly ICompanyService _companyService;
        public JobController(IJobService jobService, ICompanyService companyService)
        {
            _jobService = jobService;
            _companyService = companyService;
        }
        [HttpGet]
        [Route("getByCompanyId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var job = await _jobService.GetByCompanyIdAsync(id);
            if (job.Count()==0)
                return NotFound();
            return Ok(job);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobDTO job)
        {
            if (job == null)
                BadRequest("job can't be empty");
            var ca = await _companyService.GetByIdAsync(job.CompanyId);
            if (ca == null)
                return NotFound("company information is is missing or faulty");
            bool res = await _jobService.AddAsync(job);
            if (res)
                return Ok(job);
            return BadRequest("job not registered");
        }

    }
}
