using System;
using Xunit;
using FakeItEasy;
using ScheduleAPI.Controllers;
using ScheduleAPI.Services.Schedules;
using ScheduleAPI.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ScheduleAPI.Test
{
    public class ScheduleControllerTest
    {
        [Fact]
        public void GetSchedulesReturnsTheCorrectNumberOfSchedules()
        {
          
            //Arrenge
            int userid = 1;
            string title = "schedule 1";

            int expectedCount = 1;
            var scheduleService =new ScheduleService();
            
            var controller = new SchedulesController(scheduleService);

            //Act
            var actionResult = controller.GetSchedules(userid, title, null);

            //Assert
            var result = actionResult as OkObjectResult;
            var returnSchedules = result.Value as List<Schedule>;
            Assert.Equal(expectedCount, returnSchedules.Count);
        }
    }
}
