using PackingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PackingList.Controllers
{
    public class ItemsController : ApiController
    {
        private ItemRepository repo = null;

        public ItemsController()
        {
            this.repo = new ItemRepository();
        }

        public HttpResponseMessage Get()
        {
            Item[] items = repo.GetAllItems().ToArray();
            return Request.CreateResponse<IEnumerable<Item>>(HttpStatusCode.OK, items);
        }

        // GET /api/values/5
        public HttpResponseMessage Get(int Id)
        {
            return Request.CreateResponse<String>(HttpStatusCode.OK, Id.ToString());
        }

    }
}
