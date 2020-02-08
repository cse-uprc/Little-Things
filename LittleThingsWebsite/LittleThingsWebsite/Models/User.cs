using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LittleThingsWebsite.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPhrase { get; set; }

        public ICollection<Habit> Habits { get; set; }
    }
}