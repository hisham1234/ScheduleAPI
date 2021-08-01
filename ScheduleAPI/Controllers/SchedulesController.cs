using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleAPI.Services.Schedules;
using ScheduleAPI.Models;

namespace ScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private IScheduleRepository _scheduleRepository;
        public SchedulesController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet]
        [Route("users/{userid}")]
        public IActionResult GetSchedules(int userid,string title, DateTime? startDateTime)
        {
            var schedules = _scheduleRepository.GetAllSchedules(userid,title,startDateTime);
            return Ok(schedules);
        }

        [HttpGet("{id}",Name ="GetSchedule")]
        public ActionResult<Schedule> GetSchedules(int id)
        {
            var schedules = _scheduleRepository.GetSchedule(id);
            if(schedules!=null)
            {
                return Ok(schedules);
            }
            return NotFound();
           
        }

      

        [HttpPost]
        public ActionResult<Schedule> AddSchedule(Schedule schedule)
        {
            
                var createdSchedule= _scheduleRepository.AddSchedule(schedule);
                return CreatedAtRoute("GetSchedule",new { id=createdSchedule.Id},createdSchedule);
                       
            
        }

        [HttpPut("{id}")]
        public ActionResult<Schedule> UpdateSchedule(int id,Schedule schedule)
        {
            try
            {
                
                if (id != schedule.Id)
                    return NotFound();                
                else
                {
                    var updatedSchedule = _scheduleRepository.UpdateSchedule(id, schedule);
                    return CreatedAtRoute("GetSchedule", new { id = updatedSchedule.Id }, updatedSchedule);
                }
                  
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
           


        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSchedule(int id)
        {
            try
            {
                if (_scheduleRepository.DeleteSchedule(id))
                    return Ok("Deleted");
                else
                    return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
