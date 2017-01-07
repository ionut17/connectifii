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
        public IActionResult Get()
        {
            var result = Repository.GetAll().ToArray();
            if (result.Length == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetResource[controller]")]
        public IActionResult Get(Guid id)
        {
            var result = Repository.GetById(id);
            if (result == null)
                return NotFound("Id " + id + " does not exist");
            return Ok(result);
        }
    }
}