using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LittleThingsWebsite.Models
{
    class LittleThingsContext : DbContext
    {
        //private MongoDB.Driver.MongoClient client;
        //private IMongoDatabase database;
        public LittleThingsContext()
        {
            //const string CONNECTION_FORMAT
            //    = "mongodb+srv://{}@conversationstarter-dcvon.gcp.mongodb.net/test?retryWrites=true&w=majority";
            //client = new MongoClient(String.Format(CONNECTION_FORMAT, "admin:littlethings"));
            //database = client.GetDatabase("test");

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LittleThingsContext>());
        }

        //protected IMongoQueryable<User> GetUsers()
        //{
        //    using MongoDB.Driver.Linq;

        //    database.GetCollection("Users").Find
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCompletion> CompletedHabits { get; set; }
    }
}