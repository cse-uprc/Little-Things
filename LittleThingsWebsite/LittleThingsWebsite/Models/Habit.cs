using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LittleThingsWebsite.Models
{
    public class Habit
    {
        public int HabitID { get; set; }
        public string HabitName { get; set; }
        public int TimeLimit { get; set; }
        public int HabitFrequency { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}