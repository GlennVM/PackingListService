using PackingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingList.DAL
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<User>
            {
                new User{Name = "Glenn", Password = "Test", ItemDictionary = new List<TripComponent>(), Trips = new List<TripComponent>()},
                new User{Name = "Dean", Password = "Test", ItemDictionary = new List<TripComponent>(), Trips = new List<TripComponent>()},
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}