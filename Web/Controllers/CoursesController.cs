using System;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/courses")]
    public class CoursesController : AbstractController<Course>
    {
        public CoursesController()
        {
            Repository = new CourseRepository();
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseDto courseDto)
        {
            if (courseDto == null)
                return BadRequest();

            var course = new Course(courseDto);

            if (Repository.GetAll().Any(c => c.Title.Equals(course.Title) && (c.Year == course.Year)))
                return BadRequest("Course already in DB.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Repository.Create(course);
            return CreatedAtRoute("GetResourcecourses", new {id = course.Id}, course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] CourseDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newCourse = new Course
            {
                Id = id,
                Title = entity.Title,
                Year = entity.Year
            };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newCourse);
            return new NoContentResult();
        }
    }
}