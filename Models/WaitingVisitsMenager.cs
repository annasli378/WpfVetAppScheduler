using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppScheduler.Models.DB;

namespace WpfAppScheduler.Models
{
    class WaitingVisitsMenager
    {
        public List<WaitingVisit> GetAllVisits()
        {
            List<WaitingVisit> result;
            using (var context = new WaitingVisitContext())
            {
                result = context.WaitingVisits.ToList()
                                      .Select(x => new WaitingVisit(x))
                                      .ToList();
            }
            return result;
        }
        public WaitingVisit GetVisit(int id)
        {
            WaitingVisit result = null;
            using (var context = new WaitingVisitContext())
            {
                WaitingVisit v = context.WaitingVisits.FirstOrDefault(x => x.VisitId == id);
                if (v != null)
                {
                    result = new WaitingVisit(v);
                }
            }
            return result;
        }

        public bool RemoveVisit(int id)
        {
            using (var context = new WaitingVisitContext())
            {
                //WaitingVisit v = context.WaitingVisits.FirstOrDefault(x => x.VisitId == id);
                WaitingVisit v = context.WaitingVisits.ToList()[id];
                Console.WriteLine(v + "-->" + id);
                if (v != null)
                {
                    context.WaitingVisits.Remove(v);
                    context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}

  