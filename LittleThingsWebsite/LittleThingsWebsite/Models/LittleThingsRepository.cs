using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace LittleThingsWebsite.Models
{
    public class LittleThingsRepository
    {
        private LittleThingsContext _Context = new LittleThingsContext();

        public bool AddUserToContext(User theUser)
        {
            bool HabitsWereAddedToTheContext = false;

            if (!TheUserExistsInContext(theUser))
            {
                _Context.Users.Add(theUser);

                foreach(Habit h in theUser.Habits)
                {
                    HabitsWereAddedToTheContext = HabitsWereAddedToTheContext || AddHabitToContext(h);
                }

                if (!HabitsWereAddedToTheContext)
                    _Context.SaveChanges();

                return true;
            }

            return false;
        }
        public bool AddHabitToContext(Habit theHabit)
        {
            if (!TheHabitExistsInContext(theHabit))
            {
                _Context.Habits.Add(theHabit);
                _Context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddHabitToUser(Habit theHabit, User theUser)
        {
            if (!TheHabitExistsInUser(theHabit, theUser))
            {
                theUser.Habits.Add(theHabit);
                bool ContextWasModified = AddHabitToContext(theHabit);

                if (!ContextWasModified)
                    _Context.SaveChanges();

                return true;
            }

            return false;
        }
        public bool RemoveHabitFromContext(Habit theHabit)
        {
            if (TheHabitExistsInContext(theHabit))
            {
                _Context.Habits.Remove(theHabit);
                _Context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool RemoveUserFromContext(User theUser)
        {
            if (TheUserExistsInContext(theUser))
            {
                foreach (Habit h in theUser.Habits)
                {
                    if (!TheHabitExistsInOtherUsers(h, theUser))
                    {
                        _Context.Habits.Remove(h);
                    }
                }

                _Context.Users.Remove(theUser);
                _Context.SaveChanges();
                return true;
            }

            return false;
        }
        
        public bool TheHabitExistsInContext(Habit theHabit)
        {
            if (theHabit != null)
                return _Context.Habits
                    .Where(h => h == theHabit)
                    .Any();
            else
                return false;
        }
        public bool TheHabitExistsInUser(Habit theHabit, User theUser)
        {
            if (theHabit != null && theUser != null)
                return theUser.Habits
                    .Where(h => h == theHabit)
                    .Any();
            else
                return false;
        }
        public bool TheUserExistsInContext(User theUser)
        {
            if (theUser != null)
                return _Context.Users
                    .Where(u => u == theUser)
                    .Any();
            else
                return false;
        }
        public bool TheHabitExistsInOtherUsers(Habit theHabit, User theUser)
        {
            if (theHabit != null && theUser != null)
            {
                return _Context.Users                  
                    .Where(
                        u => u != theUser && TheHabitExistsInUser(theHabit, u)
                    ).Any();       
            }
            else
            {
                return false;
            }
        }
        public bool TheHabitExistsInAnyUsers(Habit theHabit)
        {
            if (theHabit != null)
                return _Context.Users
                    .Where(u => TheHabitExistsInUser(theHabit, u))
                    .Any();
            else
                return false;
        }
    }
}