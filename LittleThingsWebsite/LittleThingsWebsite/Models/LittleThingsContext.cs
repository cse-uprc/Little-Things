using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace LittleThingsWebsite.Models
{
    class LittleThingsContext : DbContext
    {
        public LittleThingsContext()
            : base()
            => Database.SetInitializer(new LittleThingsContextInitializer());

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCompletion> HabitCompletions { get; set; }
    }
}