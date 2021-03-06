﻿using System;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/students")]
    public class StudentsController : AbstractController<Student>
    {
        private readonly IMapper _mapper;
        public ICourseRepository<Course> CourseRepository;
        public IStudentRepository<Student> StudentRepository;

        public StudentsController(IMapper mapper, IStudentRepository<Student> studentRepository,
            ICourseRepository<Course> courseRepository)
        {
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
            Repository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet("registrationnumber/{registrationNumber}")]
        public IActionResult Get(string registrationNumber)
        {
            var result = StudentRepository.GetByRegistrationNumber(registrationNumber);
            if (result == null)
                return NotFound("Registration number " + registrationNumber + " does not exist");
            return Ok(result);
        }

        [HttpGet("{id}/courses")]
        public IActionResult GetCourses(Guid id)
        {
            var coursesIds = StudentRepository.GetStudentCourses(id);
            if (coursesIds == null)
                return NotFound("Id " + id + "does not exists.");
            var result = CourseRepository.GetByIds(coursesIds);
            if (result == null)
                return NotFound("This student is not enrolled to any courses.");
            return Ok(result);
        }

        [HttpGet("registrationnumber/{registrationNumber}/courses")]
        public IActionResult GetCourses(string registrationNumber)
        {
            var coursesIds = StudentRepository.GetStudentCourses(registrationNumber);
            if (coursesIds == null)
                return NotFound("Registration number " + registrationNumber + "does not exists.");
            var result = CourseRepository.GetByIds(coursesIds);
            if (result == null)
                return NotFound("This student is not enrolled to any courses.");
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] StudentDto entity)
        {
            if (entity == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //TODO solve conflict at inserting group (not allowing null)

            var newStudent = _mapper.Map<StudentDto, Student>(entity);
            newStudent.Id = new Guid();

            StudentRepository.Create(newStudent);
            return CreatedAtRoute("GetResourcestudents", new {id = newStudent.Id}, entity);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] StudentDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newStudent = _mapper.Map<StudentDto, Student>(entity);
            newStudent.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentRepository.Update(newStudent);
            return new NoContentResult();
        }
    }
}