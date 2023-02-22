using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppScheduler.Models.DB;
using WpfAppScheduler.Models.Info;

namespace WpfAppScheduler.Models
{
    class VisitsMenager
    {
        public List<VisitInfo> GetAllVisits()
        {
            List<VisitInfo> result;
            using (var context = new VisitsContext())
            {
                result = context.Visits.ToList()
                                      .Select(x => new VisitInfo(x))
                                      .ToList();
            }
            return result;
        }
        public VisitInfo GetVisit(int id)
        {
            VisitInfo result = null;
            using (var context = new VisitsContext())
            {
                Visit visit = context.Visits.FirstOrDefault(x => x.VisitId == id);
                if (visit != null)
                {
                    result = new VisitInfo(visit);
                }
            }
            return result;
        }

        public List<VisitInfo> GetVisits(int indexStart, int elementsCount)
        {
            List<VisitInfo> result;
            using (var context = new VisitsContext())
            {
                result = context.Visits.OrderBy(x => x.VisitId)
                                      .Skip(indexStart)
                                      .Take(elementsCount)
                                      .ToList()
                                      .Select(x => new VisitInfo(x))
                                      .ToList();
            }
            return result;
        }

        public List<VisitInfo> GetVisitsForDay(DateTime day)
        {
            List<VisitInfo> result;
            using (var context = new VisitsContext())
            {
                result = context.Visits.Where(x => x.VisitDate.Day == day.Day && x.VisitDate.Month == day.Month && x.VisitDate.Year == day.Year)
                                              .ToList().Select(x => new VisitInfo(x))
                                              .ToList();
            }
            return result;
        }


        public bool CheckIfVisitExists(Visit visit)
        {
            Visit DBVisit = null;
            List<VisitInfo> visitsForDate;
            using (var context = new VisitsContext())
            {
                DBVisit = context.Visits.FirstOrDefault(x => x.VisitId == visit.VisitId );
                visitsForDate = context.Visits.Where(x => x.VisitDate == visit.VisitDate)
                                              .ToList().Select(x => new VisitInfo(x))
                                              .ToList(); 
                foreach(var v in visitsForDate)
                {      
                        if (visit.Start >= v.Start && visit.End <= v.End)
                        {
                            return true;
                        } 
                }

                if (DBVisit == null)
                {
                        return false;
                }
            }
            return true;
        }

        public bool CheckIfVisitDateCorrect(Visit visit)
        {
            
            List<VisitInfo> visitsForDate = new List<VisitInfo>();
            using (var context = new VisitsContext())
            {
                visitsForDate = context.Visits.Where(x => x.VisitDate == visit.VisitDate)
                                              .ToList().Select(x => new VisitInfo(x))
                                              .ToList(); 
                foreach (var v in visitsForDate)
                {
                    if (visit.VisitDate == v.VisitDate)
                    {
                        //początek nowej wizyty jest między początkiem a końcem istniejącej wzyty
                        if (visit.Start >= v.Start && visit.Start < v.End)
                        {
                            return false;
                        }
                        //koniec nowej wizyty jest między początkiem a końcem istniejącej wzyty
                        else if (visit.End > v.Start && visit.End <= v.End)
                        {
                            return false;
                        }
                        //początek i koniec wizyty dookoła istneijącej wizyty
                        else if (visit.Start <= v.Start && visit.End >= v.End)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return true;
            }
            
        }
        public bool AddNewVisit(Visit visit)
        {
            if (!CheckIfVisitExists(visit))
            {
                using (var context = new VisitsContext())
                {      
                    context.Visits.Add(visit);
                    context.SaveChanges();
                    return true;
                }
            }
            else
            {
                EditVisit(visit);
            }
            return false;
        }
        public bool EditVisit(Visit visit)
        {
            using (var context = new VisitsContext())
            {
                Visit dbVisit = context.Visits.FirstOrDefault(x => x.VisitId == visit.VisitId);

                if (dbVisit == null)
                {
                    return false;
                }

                dbVisit.Name = visit.Name;
                dbVisit.Email = visit.Email;
                dbVisit.Phone = visit.Phone;
                dbVisit.Note = visit.Note;
                dbVisit.VisitDate = visit.VisitDate;
                dbVisit.Start = visit.Start;              
                context.SaveChanges();               
                return true;
            }
        }

        public bool RemoveVisit(int id)
        {
            using (var context = new VisitsContext())
            {
                Visit visit = context.Visits.FirstOrDefault(x => x.VisitId == id);
                if (visit != null)
                {
                    context.Visits.Remove(visit);
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
