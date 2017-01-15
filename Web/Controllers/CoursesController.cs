using System;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : AbstractController<Course>
    {
        public CourseRepository CourseRepository = new CourseRepository();
        public TeacherRepository TeacherRepository = new TeacherRepository();
        public StudentRepository StudentRepository = new StudentRepository();

        public CoursesController()
        {
            Repository = CourseRepository;
        }

        [HttpGet("{id}/students")]
        public IActionResult GetStudents(Guid id)
        {
            var studentsIds = CourseRepository.GetCourseStudents(id);
            if (studentsIds == null)
                return NotFound("Id " + id + "does not exists.");
            var result = StudentRepository.GetByIds(studentsIds);
            if (result == null)
                return NotFound("This course has no students enrolled.");
            return Ok(result);
        }

        [HttpGet("{id}/teachers")]
        public IActionResult GetTeachers(Guid id)
        {
            var teachersIds = CourseRepository.GetCourseTeachers(id);
            if (teachersIds == null)
                return NotFound("Id " + id + "does not exists.");
            var result = TeacherRepository.GetByIds(teachersIds);
            if (result == null)
                return NotFound("This course has no teachers.");
            return Ok(result);
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
    }
}