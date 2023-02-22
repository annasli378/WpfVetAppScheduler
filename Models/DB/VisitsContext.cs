using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace WpfAppScheduler.Models.DB
{
    class VisitsContext : DbContext
    {
        public DbSet<Visit> Visits { get; set; }

        public VisitsContext() : base("Visits")
        {

        }
    }
}
