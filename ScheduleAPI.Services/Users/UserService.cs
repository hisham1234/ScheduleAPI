using ScheduleAPI.DataAccess;
using ScheduleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleAPI.Services.Users
{
    public class UserService : IUserRepository
    {
        private ScheduleDbContext _db = new ScheduleDbContext();
        public User CreateUser(User user)
        {
            var _user = new User();
            try
            {


                _db.User.Add(user);
                _db.SaveChanges();
                _user = _db.User.Find(user.Id);

                return user;


            }
            catch (Exception)
            {

                return user;
            }
        }

        public User GetUser(int id)
        {
            var user = new User();
            user = _db.User.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            return user;
        }
    }
}
