using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppScheduler.Models.DB
{
    class WaitingVisit
    {
        [Key]
        public int VisitId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hour { get; set; }

        public WaitingVisit()
        {

        }

        public WaitingVisit(string name, string email, string phone, string note, DateTime dateTime, DateTime hour)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Note = note;
            Data = dateTime;
            Hour = hour;
        }
        public WaitingVisit(WaitingVisit v)
        {
            Name = v.Name;
            Phone = v.Phone;
            Email = v.Email;
            Note = v.Note;
            Data = v.Data;
            Hour = v.Hour;
        }
    }
}
