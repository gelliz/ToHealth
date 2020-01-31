using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToHealth.DB
{
    public partial class DBToHealth : DbContext
    {
        public DBToHealth() : base("DBToHealth") {}

        public DbSet<User> Users { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Reminders> Reminders { get; set; }

        public DbSet<Medicaments> Medicaments { get; set; }

        public DbSet<Diseases> Diseases { get; set; }
    }
}

