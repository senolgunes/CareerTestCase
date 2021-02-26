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
    [Route("api/experince")]
    public class ExperinceController : Controller
    {

        private IExperinceService _experinceService;
        private readonly ICVService _cvService;
        public ExperinceController(IExperinceService experinceService, ICVService cVService )
        {
            _experinceService = experinceService;
            _cvService = cVService;
        }
        [HttpGet]
        [Route("getByUserId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cv = await _cvService.GetByUserIdAsync(id);
            if (cv == null) return NotFound("Experince info not found");
            var ex = await _experinceService.GetByUserIdAsync(id);
            if (ex.Count() == 0)
                return NotFound("Experince info not found");
            return Ok(ex);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExperinceDTO experince)
        {
            if (experince == null || experince.UserId == 0)
                BadRequest("experince and UserId can't be empty");
            var cv=await _cvService.GetByUserIdAsync(experince.UserId);
            if (cv == null)
                return NotFound("Cv info not found ");
            bool res = await _experinceService.AddAsync(experince);
            if (res)
                return Ok(experince);
            return BadRequest("User of experince not registered");
        }
        [HttpGet]
        [Route("getTotalExperinceByUserId/{id}")]
        public async Task<IActionResult> GetTotalExperince(int id)
        {
             var cv = await _cvService.GetByUserIdAsync(id);
            if(cv==null) return NotFound("cv information not found");
            var ex = await _experinceService.GetTotalExperience(id);
            if (ex == null)
                return NotFound("Experince information not found");
            return Ok(ex);
        }
    }
}
