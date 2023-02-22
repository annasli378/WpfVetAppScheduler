using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppScheduler.Models.Info;

namespace WpfAppScheduler.Models.DB
{
    class Visit
    {
        [Key]
        public int VisitId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
        
        public string Note { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Visit()
        {

        }

        public Visit(string name, string phone, string email, string note, DateTime dateTime, DateTime start, DateTime end)
        {
            Name = name;           
            Phone = phone;
            Email = email;
            Note = note;
            VisitDate = dateTime;
            Start = start;
            End = end;
        }

        public Visit(VisitInfo visitInfo) :
           this(
              visitInfo.Name,
              visitInfo.Phone,
              visitInfo.Email,
              visitInfo.Note,
              visitInfo.VisitDate,
              visitInfo.Start,
              visitInfo.End)
        { }


    }
}
