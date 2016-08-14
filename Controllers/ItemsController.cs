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

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Item[] items = repo.GetAllItems().ToArray();
            return Request.CreateResponse<IEnumerable<Item>>(HttpStatusCode.OK, items);
        }

        [HttpGet]
        // GET /api/values/5
        public HttpResponseMessage Get(int Id)
        {
            return Request.CreateResponse<String>(HttpStatusCode.OK, Id.ToString());
        }

        [HttpPost]
        public HttpResponseMessage Post(Item item)
        {
            repo.AddItem(item);
            return Request.CreateResponse<IEnumerable<Item>>(HttpStatusCode.OK, repo.GetAllItems().ToArray());
        }
    }
}
