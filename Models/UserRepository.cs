using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class UserRepository : IUserRepository
    {
        User[] user = new User[]
        {
            new User {Name = "Glenn", Password = "Test", Trips = new Trip[]
                {
                    new Trip {Id = 1, Name = "Frankrijk" },
                    new Trip {Id = 2, Name = "Nederland" }
                }
            },
            new User {Name = "Jens", Password = "Test" }
        };
        public User AddUser(User user)
        {
            this.user.ToList().Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            for (int i = 0; i < this.user.Length; i++)
            {
                if (this.user[i].Name == user.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.user;
        }

        public User GetUser(string name)
        {
            for (int i = 0; i < this.user.Length; i++)
            {
                if (this.user[i].Name == name)
                {
                    return this.user[i];
                }
            }
            return null;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}