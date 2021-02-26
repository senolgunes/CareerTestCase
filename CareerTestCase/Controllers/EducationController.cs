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
    [Route("api/education")]
    public class EducationController : ControllerBase
    {
        private IEducationService _educationService;
        private readonly ICVService _cvService;
        public EducationController(IEducationService educationService, ICVService cVService)
        {
            _educationService = educationService;
            _cvService = cVService;
        }
        [HttpGet]
        [Route("getByUserId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var edu = await _educationService.GetByUserIdAsync(id);
            if (edu.Count() == 0)
                return NotFound();
            return Ok(edu);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EducationDTO edu)
        {
            if (edu == null)
                BadRequest("Education Information can't be empty");
            var cv = await _cvService.GetByUserIdAsync(edu.UserId);
            if (cv == null)
                return NotFound("Cv info not found");
            bool res = await _educationService.AddAsync(edu);
            if (res)
                return Ok(edu);
            return BadRequest("User of Education Information not registered");
        }

    }
}
