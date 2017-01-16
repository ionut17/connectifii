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
        private readonly IMapper _mapper;
        public CourseRepository CourseRepository = new CourseRepository();
        public StudentRepository StudentRepository = new StudentRepository();
        public TeacherRepository TeacherRepository = new TeacherRepository();

        public CoursesController(IMapper mapper)

        {
            Repository = CourseRepository;
            _mapper = mapper;
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
        public IActionResult CreateCourse([FromBody] CourseDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newCourse = _mapper.Map<CourseDto, Course>(entity);
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

            var newCourse = _mapper.Map<CourseDto, Course>(entity);
            newCourse.Id = id;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newCourse);
            return new NoContentResult();
        }
    }
}