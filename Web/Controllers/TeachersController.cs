using System;
using System.Linq;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/teachers")]
    public class TeachersController : AbstractController<Teacher>
    {
        private readonly IMapper Mapper;

        public TeachersController(IMapper mapper)
        {
            Repository = new TeacherRepository();
            Mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newTeacher = Mapper.Map<TeacherDto, Teacher>(entity);
            newTeacher.Id = new Guid();

            if (Repository.GetAll().Any(t => t.LastName.Equals(newTeacher.LastName) &&
                t.FirstName.Equals(newTeacher.FirstName) &&
                (t.BirthDate == newTeacher.BirthDate)))
                return BadRequest("Teacher already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(newTeacher);
            return CreatedAtRoute("GetResourceteachers", new { id = newTeacher.Id }, newTeacher);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(Guid id, [FromBody] TeacherDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newTeacher = Mapper.Map<TeacherDto, Teacher>(entity);
            newTeacher.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newTeacher);
            return new NoContentResult();
        }

    }
}