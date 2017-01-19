using System;
using System.Linq;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/teachers")]
    public class TeachersController : AbstractController<Teacher>
    {
        private readonly IMapper _mapper;
        public ICourseRepository<Course> CourseRepository;
        public ITeacherRepository<Teacher> TeacherRepository;

        public TeachersController(IMapper mapper, ITeacherRepository<Teacher> teacherRepository, ICourseRepository<Course> courseRepository)
        {
            TeacherRepository = teacherRepository;
            CourseRepository = courseRepository;
            Repository = TeacherRepository;
            _mapper = mapper;
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

        [Authorize]
        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newTeacher = _mapper.Map<TeacherDto, Teacher>(entity);
            newTeacher.Id = new Guid();

            if (Repository.GetAll().Any(t => t.LastName.Equals(newTeacher.LastName) &&
                                             t.FirstName.Equals(newTeacher.FirstName) &&
                                             (t.BirthDate == newTeacher.BirthDate)))
                return BadRequest("Teacher already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(newTeacher);
            return CreatedAtRoute("GetResourceteachers", new {id = newTeacher.Id}, newTeacher);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(Guid id, [FromBody] TeacherDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newTeacher = _mapper.Map<TeacherDto, Teacher>(entity);
            newTeacher.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Update(newTeacher);
            return new NoContentResult();
        }
    }
}