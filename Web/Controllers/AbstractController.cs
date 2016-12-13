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
            var result = Repository.GetAll().Select(s => Json(s)).ToArray();
            if (result.Length == 0)
                return NotFound();
            return Ok(Json(result));
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var result = Repository.GetById(id);
            if (result == null)
                return NotFound("Id " + id + " does not exist");
            return Ok(Json(result));
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