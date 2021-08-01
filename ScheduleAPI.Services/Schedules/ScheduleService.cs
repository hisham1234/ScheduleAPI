using Microsoft.EntityFrameworkCore;
using ScheduleAPI.DataAccess;
using ScheduleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleAPI.Services.Schedules
{
    public class ScheduleService : IScheduleRepository
    {
        private ScheduleDbContext _db = new ScheduleDbContext();
        public List<Schedule> GetAllSchedules(int userid)
        {
            
            return _db.Schedule.Where(x=>x.UserId==userid).ToList(); 

        }

        public Schedule AddSchedule(Schedule schedule)
        {
            var _schdule = new Schedule();
            try
            {
                
                
                    _db.Schedule.Add(schedule);
                    _db.SaveChanges();
                    _schdule= _db.Schedule.Find(schedule.Id); 
                    
                    return _schdule;
                
                
            }
            catch (Exception)
            {

                return _schdule;
            }
        }

        public Schedule GetSchedule(int id)
        {
             var schedule = new Schedule();
             schedule =_db.Schedule.FirstOrDefault(x => x.Id== id);
            if(schedule!=null)
            {
                return schedule;
            }
            return schedule;
        }

        public Schedule UpdateSchedule(int id ,Schedule schedule)
        {
               var _schdule = new Schedule();



           
                _db.Schedule.Update(schedule);
                _db.SaveChanges();
                _schdule = _db.Schedule.Find(schedule.Id);

                return _schdule;


           
        }
        public bool DeleteSchedule(int id)
        {
            var schedule = _db.Schedule.FirstOrDefault(x => x.Id == id);
            if (schedule == null)
                return false;
            _db.Schedule.Remove(schedule);
            _db.SaveChanges();
            return true;
        }

        public List<Schedule> GetAllSchedules(int userId,string title,DateTime? startdateTime)
        {
            if(string.IsNullOrWhiteSpace(title) && startdateTime==null)
            {
                return GetAllSchedules(userId);
            }

            var listOfSchedules= _db.Schedule as IQueryable<Schedule>;

            if (startdateTime != null)
            {
                listOfSchedules = listOfSchedules.Where(x => x.StartDateTime == startdateTime && x.UserId==userId);
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                listOfSchedules = listOfSchedules.Where(x => x.Title.Contains(title) && x.UserId == userId);
            }

            return listOfSchedules.ToList();
           

            
        }
    }
}
