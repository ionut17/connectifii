using System;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Web.Controllers
{
    public class GroupsController : AbstractController<Group>
    {
        private readonly IMapper Mapper;

        public GroupsController(IMapper mapper)
        {
            Repository = new GroupRepository();
            Mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newGroup = Mapper.Map<GroupDto, Group>(entity);
            newGroup.Id = new Guid();

            if (Repository.GetAll().Any(g => g.Name.Equals(newGroup.Name) &&
                g.Year == newGroup.Year))
                return BadRequest("Group already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(newGroup);
            return CreatedAtRoute("GetResourcegroups", new { id = newGroup.Id }, newGroup);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(Guid id, [FromBody] GroupDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newGroup = Mapper.Map<GroupDto, Group>(entity);
            newGroup.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newGroup);
            return new NoContentResult();
        }

    }
}