using System;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public abstract class AbstractController<T> : Controller where T : class, IEntity
    {
        public AbstractRepository<T> Repository;

        [HttpGet]
        public ActionResult Get()
        {
            return Json(Repository.GetAll().Select(s => Json(s)).ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return Json(Repository.GetById(id));
        }

        // POST
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}