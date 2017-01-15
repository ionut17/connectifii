using System;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : AbstractController<Teacher>
    {
        public TeacherRepository TeacherRepository = new TeacherRepository();
        public CourseRepository CourseRepository = new CourseRepository();


        public TeachersController()
        {
            Repository = TeacherRepository;
        }

        [HttpGet("{id}/courses")]
        public IActionResult GetCourses(Guid id)
        {
            var coursesIds = TeacherRepository.GetTeacherCourses(id);
            if (coursesIds == null)
                return NotFound("Id " + id + "does not exists.");
            var result = CourseRepository.GetByIds(coursesIds);
            if (result == null)
                return NotFound("This teacher doesn't teach any courses.");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null)
                return BadRequest();

            var teacher = new Teacher(teacherDto);

            if (
                Repository.GetAll()
                    .Any(
                        t =>
                            t.LastName.Equals(teacher.LastName) && t.FirstName.Equals(teacher.FirstName) &&
                            (t.BirthDate == teacher.BirthDate)))
                return BadRequest("Teacher already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(teacher);
            return CreatedAtRoute("GetResourceteachers", new {id = teacher.Id}, teacher);
        }
    }
}