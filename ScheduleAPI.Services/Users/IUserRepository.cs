using ScheduleAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleAPI.Services.Users
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User GetUser(int id);

    }
}
