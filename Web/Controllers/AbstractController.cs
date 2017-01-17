using System;
using System.Linq;
using Core;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public abstract class AbstractController<T> : Controller where T : class, IEntity
    {
        public IRepository<T> Repository;

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

        [HttpPatch("{id}")]
        public IActionResult PatchEntity(Guid id, [FromBody] JsonPatchDocument<IEntity> entity)
        {
            if (entity == null)
                return BadRequest();

            var entityForUpdate = Repository.GetById(id);
            if (entityForUpdate == null)
                return NotFound("Id " + id + " does not exist");

            entity.ApplyTo(entityForUpdate, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Repository.Update(entityForUpdate);
            return Ok(entityForUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = Repository.GetById(id);
            if (entity == null)
                return BadRequest("Id " + id + " doesn't exist");
            Repository.Delete(entity);
            return NoContent();
        }
    }
}