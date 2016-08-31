using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PackingList.DAL;
using PackingList.Models;

namespace PackingList.Controllers
{
    public class UserController : ApiController
    {
        private UserContext db = new UserContext();

        // GET: api/User
        public IQueryable<User> GetUsers()
        {
            return db.Users
                .Include(t => t.Trips.Select(u => u.items))
                .Include(t => t.Trips.Select(u => u.tasks))
                .Include(u => u.ItemDictionary);
        }

        // GET: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Where(u => u.UserId == id)
                .Include(p => p.Trips.Select(g => g.items))
                .Include(j => j.Trips.Select(f => f.tasks))
                .Include(i => i.ItemDictionary)
                .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            var existingUser = db.Users.Where(u => u.UserId == id)
                .Include(p => p.Trips.Select(g => g.items))
                .Include(j => j.Trips.Select(f => f.tasks))
                .Include(i => i.ItemDictionary)
                .FirstOrDefault();

            if (existingUser != null)
            {
                // Update parent
                db.Entry(existingUser).CurrentValues.SetValues(user);

                // Update and Insert children
                foreach (var childModel in user.ItemDictionary)
                {
                    var existingChild = existingUser.ItemDictionary
                        .Where(c => c.ItemId == childModel.ItemId)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        db.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        var newChild = childModel;
                        existingUser.ItemDictionary.Add(newChild);
                    }
                }

                foreach (var childModel in user.Trips)
                {
                    var existingChild = existingUser.Trips
                        .Where(c => c.TripId == childModel.TripId)
                        .SingleOrDefault();

                    if (existingChild != null)
                    {
                        // Update child
                        db.Entry(existingChild).CurrentValues.SetValues(childModel);

                        foreach (var childModelItem in childModel.items)
                        {
                            var existingItem = childModel.items
                                .Where(d => d.ItemId == childModelItem.ItemId)
                                .SingleOrDefault();

                            if(existingItem != null)
                            {
                                db.Entry(existingItem).CurrentValues.SetValues(childModelItem);
                            }

                            else
                            {
                                var newItemChild = childModelItem;
                                existingChild.items.Add(newItemChild);
                            }
                        }

                        foreach (var childModelTask in childModel.tasks)
                        {
                            var existingTask = childModel.tasks
                                .Where(d => d.TaskId == childModelTask.TaskId)
                                .SingleOrDefault();

                            if (existingTask != null)
                            {
                                db.Entry(existingTask).CurrentValues.SetValues(childModelTask);
                            }

                            else
                            {
                                var newTaskChild = childModelTask;
                                existingChild.tasks.Add(newTaskChild);
                            }
                        }
                    }

                    else
                    {
                        // Insert child
                        var newChild = childModel;
                        existingUser.Trips.Add(newChild);
                    }
                }

                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

            return StatusCode(HttpStatusCode.NoContent);



            //db.Entry(user).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}