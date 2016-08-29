using PackingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PackingList.Controllers
{
    public class UsersController : ApiController
    {
        private UserRepository repo = null;

        public UsersController()
        {
            this.repo = new UserRepository();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            IEnumerable<User> users = this.repo.GetAllUsers();
            if(users != null)
            {
                return Request.CreateResponse<IEnumerable<User>>(HttpStatusCode.OK, users);
            } else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddUser(User user)
        {
            int userCount = repo.GetAllUsers().Count();
            User added = repo.AddUser(user);
            int upUserCount = repo.GetAllUsers().Count();

            if (userCount == upUserCount - 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
