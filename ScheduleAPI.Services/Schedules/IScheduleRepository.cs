using System;
using System.Collections.Generic;
using System.Text;
using ScheduleAPI.Models;

namespace ScheduleAPI.Services.Schedules
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAllSchedules(int userid);
        Schedule GetSchedule(int id);
        Schedule AddSchedule(Schedule schedule);
        Schedule UpdateSchedule(int id,Schedule schedule);
        List<Schedule> GetAllSchedules(int userid,string title, DateTime? startdateTime);
        bool DeleteSchedule(int id);
    }
}
