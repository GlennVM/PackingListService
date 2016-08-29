using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingList.Models
{
    interface IUserRepository
    {
        User AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUser(String name, String pass);
        User UpdateUser(User user);
        Boolean DeleteUser(User user);
    }
}
