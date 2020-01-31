using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToHealth.DB
{
    public class User
    {
        public User()
        {
            Reminders = new List<Reminders>();
        }

        public int UserId { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public UserInfo userInfo { get; set; }

        public ICollection<Reminders> Reminders;
    }
}
