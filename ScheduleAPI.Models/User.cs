using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
