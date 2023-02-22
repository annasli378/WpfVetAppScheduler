using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppScheduler.Models.DB
{
    class WaitingVisitContext : DbContext
    {
        public DbSet<WaitingVisit> WaitingVisits { get; set; }

        public WaitingVisitContext() : base("WaitingVisits")
        {

        }
    }
}
