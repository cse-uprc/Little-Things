using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LittleThingsWebsite.Models;

namespace LittleThingsWebsite
{
    public partial class _Default : Page
    {
        LittleThingsRepository Repository = new LittleThingsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User testUser = new User
                {
                    UserName = "bob",
                    UserPhrase = "Yahoo"
                };
                Habit testHabit = new Habit
                {
                    HabitName = "yes",
                    HabitFrequency = 30,
                    TimeLimit = 40
                };
                Repository.AddHabitToUser(testHabit, testUser);
                Repository.AddUserToContext(testUser);
            }

            UserGridView.DataSource = Repository.GetUsers().ToList();
            UserGridView.DataBind();

            HabitGridView.DataSource = Repository.GetHabits().ToList();
            UserGridView.DataBind();
        }
    }
}