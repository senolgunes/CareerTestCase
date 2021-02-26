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
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        //api/company/getById/3
        [HttpGet]
        [Route("ById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }
        //api/company
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyDTO company)
        {
            if (company==null)
                return BadRequest("company can't be empty");
            bool res = await _companyService.AddAsync(company);
            if (res)
                return Ok(company);
            return BadRequest("company not registered");
        }
    }
}
