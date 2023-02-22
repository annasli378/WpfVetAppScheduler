using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppScheduler.Models.DB;

namespace WpfAppScheduler.Models.Info
{
    class VisitInfo
    {

        public int VisitId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public VisitInfo()
        {

        }

        public VisitInfo(string name, string phone, string email, string note, DateTime dateTime, DateTime start, DateTime end)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Note = note;
            VisitDate = dateTime;
            Start = start;
            End = end;
        }

        public VisitInfo(Visit visit) :
          this(visit.Name,
              visit.Phone,
              visit.Email,
              visit.Note,
              visit.VisitDate,
              visit.Start,
              visit.End)
        {
            VisitId = visit.VisitId;
        }
    }
}
