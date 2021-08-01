using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Models;
using ScheduleAPI.Services.Schedules;
using ScheduleAPI.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();

        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            if(ModelState.IsValid)
            {
                var createdUser = _userRepository.CreateUser(user);
                return CreatedAtRoute("GetSchedule", new { id = createdUser.Id }, createdUser);
            }
            return StatusCode(400);
            


        }

    }
}
