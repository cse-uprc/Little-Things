using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LittleThingsWebsite.Models
{
    public class HabitCompletion
    {
        public int HabitCompletionID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("Habit")]
        public int HabitID { get; set; }
        public Habit Habit { get; set; }

        public DateTime WhenLastDone { get; set; }
    }
}