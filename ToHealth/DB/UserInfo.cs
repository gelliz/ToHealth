using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToHealth.DB
{
    public class UserInfo
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public DateTime bday { get; set; }

        public string gender { get; set; }

        public int height {get; set;}

        public int weight { get; set; }

        public User User { get; set; }

        public string disease { get; set; }
    }
}
