using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class UserRepository : IUserRepository
    {
        List<User> users = new List<User>
        {
            new User {Name = "Glenn", Password = "Test", Trips = new List<Trip>
                {
                    new Trip {Title = "Frankrijk", items = new List<Item>(), tasks = new List<Task>() },
                    new Trip {Title = "Nederland", items = new List<Item>(), tasks = new List<Task>() }
                }
            },
            new User {Name = "Jens", Password = "Test", Trips = new List<Trip>() }
        };
        public User AddUser(User user)
        {
            if(user.ItemDictionary == null)
            {
                user.ItemDictionary = new List<Item>();
            }
            if(user.Trips == null)
            {
                user.Trips = new List<Trip>();
            }

            this.users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            for (int i = 0; i < this.users.Count; i++)
            {
                if (this.users[i].Name == user.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.users;
        }

        public User GetUser(string name, string pass)
        {
            for (int i = 0; i < this.users.Count; i++)
            {
                if (this.users[i].Name.Equals(name) && this.users[i].Password.Equals(pass))
                {
                    return this.users[i];
                }
            }
            return null;
        }

        public User UpdateUser(User user)
        {
            for(int i = 0; i < this.users.Count; i++)
            {
                if(this.users[i].Name.Equals(user.Name))
                {
                    if(user.Trips == null)
                    {
                        user.Trips = new List<Trip>();
                    }
                    if(user.ItemDictionary == null)
                    {
                        user.ItemDictionary = new List<Item>();
                    }
                    this.users[i] = user;
                    return user;
                }
            }
            return null;
        }
    }
}