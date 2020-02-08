using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LittleThingsWebsite.Models
{
    class LittleThingsContextInitializer
        : DropCreateDatabaseIfModelChanges<LittleThingsContext>
    {
        public LittleThingsContextInitializer()
        {
        }

        protected override void Seed(LittleThingsContext context)
        {
            WriteProofOfConcept(context);

            base.Seed(context);
        }

        private void WriteProofOfConcept(LittleThingsContext context)
        {
            // Insert code for initializing a database
            //  for testing purposes
            User BobUser = new User
            {
                UserName = "Bob"
            };
            List<Habit> DefaultHabits = new List<Habit>
            {
                new Habit
                {
                    HabitName = "HabitA",
                    TimeLimit = 10,
                    HabitFrequency = 11,
                    User = BobUser
                },
                new Habit
                {
                    HabitName = "HabitB",
                    TimeLimit = 123,
                    HabitFrequency = 456,
                    User = BobUser
                }
            };

            DefaultHabits.ForEach(h => BobUser.Habits.Add(h));

            context.Users.Add(BobUser);
            context.Habits.AddRange(DefaultHabits);

            return;
        }
    }
}