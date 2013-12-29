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
using Zipsurance2014.Models;

namespace Zipsurance2014.Controllers
{
    public class TodoController : ApiController
    {
        private TodoContext db = new TodoContext();

        // GET api/Todo
        public IQueryable<TodoItem> GetTodoItems()
        {
            return db.TodoItems;
        }

        // GET api/Todo/5
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult GetTodoItem(int id)
        {
            TodoItem todoitem = db.TodoItems.Find(id);
            if (todoitem == null)
            {
                return NotFound();
            }

            return Ok(todoitem);
        }

        // PUT api/Todo/5
        public IHttpActionResult PutTodoItem(int id, TodoItem todoitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoitem.TodoItemId)
            {
                return BadRequest();
            }

            db.Entry(todoitem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Todo
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult PostTodoItem(TodoItem todoitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoItems.Add(todoitem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = todoitem.TodoItemId }, todoitem);
        }

        // DELETE api/Todo/5
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult DeleteTodoItem(int id)
        {
            TodoItem todoitem = db.TodoItems.Find(id);
            if (todoitem == null)
            {
                return NotFound();
            }

            db.TodoItems.Remove(todoitem);
            db.SaveChanges();

            return Ok(todoitem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoItemExists(int id)
        {
            return db.TodoItems.Count(e => e.TodoItemId == id) > 0;
        }
    }
}