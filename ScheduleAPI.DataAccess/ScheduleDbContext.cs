using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Models;
using System;

namespace ScheduleAPI.DataAccess
{
    public class ScheduleDbContext:DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }

        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = @"Data Source=KANREN-300\SQLEXPRESS;Initial Catalog=ScheduleDb;Integrated Security=True";
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(new Schedule[] {
            new Schedule
            {
                Id = 1,
            Title = "Learning .Net Core",
            Description = "Learning the newest Version",
            StartDateTime = DateTime.Now,
            EndDateTime = DateTime.Now.AddDays(3),
            UserId=2

            },
            new Schedule
            {
                 Id = 2,
            Title = "Learning Angular",
            Description = "watch tutorial",
            StartDateTime = DateTime.Now,
            EndDateTime = DateTime.Now.AddDays(3),
            UserId=1
            }


           }); ;

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User{Id=1,UserName="Hisham" ,Password="123"},
                new User{Id=2,UserName="Fary",Password="321"}
            });
        }
    }
}
