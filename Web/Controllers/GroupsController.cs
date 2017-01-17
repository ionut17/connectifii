using System;
using System.Linq;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GroupsController : AbstractController<Group>
    {
        private readonly IMapper _mapper;

        public GroupsController(IMapper mapper, IGroupRepository<Group> groupRepository)
        {
            Repository = groupRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newGroup = _mapper.Map<GroupDto, Group>(entity);
            newGroup.Id = new Guid();

            if (Repository.GetAll().Any(g => g.Name.Equals(newGroup.Name) &&
                                             (g.Year == newGroup.Year)))
                return BadRequest("Group already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(newGroup);
            return CreatedAtRoute("GetResourcegroups", new {id = newGroup.Id}, newGroup);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(Guid id, [FromBody] GroupDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newGroup = _mapper.Map<GroupDto, Group>(entity);
            newGroup.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newGroup);
            return new NoContentResult();
        }
    }
}