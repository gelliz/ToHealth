using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToHealth.DB
{
    public class Reminders
    {
        [Key]
        public int RemindersId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime time { get; set; }

        public DateTime dateStart { get; set; }

        public DateTime dateFinish { get; set; }

        public string note { get; set; }

        public int fulfillment { get; set; }
    }
}
