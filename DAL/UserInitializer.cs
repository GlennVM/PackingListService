﻿using PackingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingList.DAL
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            List<Item> items = new List<Item>
            {
                new Item {Name = "Broek", Amount = 1, Category = "Clothing", Checked = false }
            };

            List<Trip> trips = new List<Trip>
            {
                new Trip {Title = "Denemarken", items = items, tasks = new List<Task>() },
                new Trip {Title = "Duitsland", items = new List<Item>(), tasks = new List<Task>() }
            };

            List<Item> itemDict = new List<Item>
            {
                new Item {Name = "Broek" },
                new Item {Name = "T-Shirt" }
            };

            var users = new List<User>
            {
                new User{Name = "Glenn", Password = "Test", ItemDictionary = itemDict, Trips = trips},
                new User{Name = "Dean", Password = "Test", ItemDictionary = new List<Item>(), Trips = new List<Trip>()},
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}