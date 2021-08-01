using System;

namespace ScheduleAPI.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    
}
