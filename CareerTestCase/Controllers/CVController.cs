using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CareerTestCase.Business.Abstract;
using CareerTestCase.Model;
using Microsoft.AspNetCore.Mvc;

namespace CareerTestCase.Controllers
{
    [ApiController]
    [Route("api/cv")]
    public class CVController : Controller
    {
        private readonly ICVService _cvService;
        private readonly IEducationService _educationService;
        private readonly IExperinceService _experinceService;
        private readonly IMapper _mapper;
        public CVController(IMapper mapper  ,ICVService cvService, IEducationService educationService, IExperinceService experinceService)
        {
            _cvService = cvService;
            _educationService = educationService;
            _experinceService = experinceService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cv = await _cvService.GetByUserIdAsync(id);
            if (cv == null)
                return NotFound();
            return Ok(cv);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CvDTO cv)
        {
            if (cv == null)
                BadRequest("Cv can't be empty");
            bool res = await _cvService.AddAsync(cv);
            if (res)
                return Ok(cv);
            return BadRequest("Cv not registered");
        }
        [HttpGet]
        [Route("getByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(int userid)
        {
            var cv = await _cvService.GetByUserIdAsync(userid);
            if (cv == null)
                return NotFound();
            return Ok(cv);
        }
        [HttpGet]
        [Route("getDetailByUserId/{id}")]
        public async Task<ActionResult> GetCvDetail(int id)
        {
            var cvTitle = await _cvService.GetByUserIdAsync(id);
            if (cvTitle == null) return NoContent();
            var cvEdu = await _educationService.GetByUserIdAsync(id);
            var exp = await _experinceService.GetByUserIdAsync(id);
            return Ok( new CvDetail()
            {
                CvName = _mapper.Map<CvDTO>(cvTitle),
                Educations = cvEdu,
                Experince = exp
            });
        }
    }
}
