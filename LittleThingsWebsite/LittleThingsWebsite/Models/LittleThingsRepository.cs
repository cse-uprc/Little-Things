using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleThingsWebsite.Models
{
    public class LittleThingsRepository
    {
        private LittleThingsContext _Context = new LittleThingsContext();

        public bool AddUser(User theUser)
        {
            if (theUser != null)
            {
                int DuplicateCount = _Context.Users
                    .Where(u => theUser == u)
                    .Count();

                if (DuplicateCount == 0)
                {
                    _Context.Users.Add(theUser);
                    _Context.Habits.AddRange(theUser.Habits);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveHabit(Habit theHabit)
        {
            if (theHabit != null)
            {
                int DuplicateCount = _Context.Habits
                    .Where(h => theHabit == h)
                    .Count();

                if (DuplicateCount > 0)
                {
                    _Context.Habits.Remove(theHabit);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveUser(User theUser)
        {
            if (theUser != null)
            {
                int DuplicateCount = _Context.Users
                    .Where(u => theUser == u)
                    .Count();

                if (DuplicateCount > 0)
                {
                    _Context.Users.Remove(theUser);
                    return true;
                }
            }

            return false;
        }
    }
}