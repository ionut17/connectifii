using System;
using System.Linq;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/courses")]
    public class CoursesController : AbstractController<Course>
    {
        private readonly IMapper Mapper;

        public CoursesController(IMapper mapper)
        {
            Repository = new CourseRepository();
            Mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newCourse = Mapper.Map<CourseDto, Course>(entity);
            newCourse.Id = new Guid();

            if (Repository.GetAll().Any(c => c.Title.Equals(newCourse.Title) && (c.Year == newCourse.Year)))
                return BadRequest("Course already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(newCourse);
            return CreatedAtRoute("GetResourcecourses", new {id = newCourse.Id}, newCourse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] CourseDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newCourse = Mapper.Map<CourseDto, Course>(entity);
            newCourse.Id = id;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newCourse);
            return new NoContentResult();
        }
    }
}