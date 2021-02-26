using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerTestCase.Business.Abstract;
using CareerTestCase.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerTestCase.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user=await _userService.GetByIdAsync(id);
            if (user==null)
            {
                return NotFound("user not found");
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            if (user == null)
                BadRequest("User can't be empty");
            bool res=await _userService.AddAsync(user);
            if (res)
                return Ok(user);
            return BadRequest("User not registered");
         }
    }
}
