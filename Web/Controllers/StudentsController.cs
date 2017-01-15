﻿using System;
using System.Collections.Generic;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/students")]
    public class StudentsController : AbstractController<Student>
    {
        public CourseRepository CourseRepository = new CourseRepository();
        public StudentRepository StudentRepository = new StudentRepository();

        public StudentsController()
        {
            Repository = StudentRepository;
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

        [HttpPost]
        public IActionResult Create([FromBody] StudentDTO entity)
        {
            if (entity == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //TODO solve conflict at inserting group (not allowing null)
            var newId = new Guid();
            var newStudent = new Student
            {
                Id = newId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                RegistrationNumber = entity.RegistrationNumber,
                Year = entity.Year
            };

            Repository.Create(newStudent);

            return CreatedAtRoute("GetResourceStudents", new {id = newId}, entity);
        }
    }
}

/*
 [HttpPost]
        public IActionResult Post([FromBody] StudentDTO entity)
        {
            if (entity == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid newId = new Guid();
            var newStudent = new Student
            {
                Id = newId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = DateTime.Now,
                Courses = new List<Course>(),
                Group = "4A5",
                RegistrationNumber = "hfha813187",
                Year = 2
            };

            Repository.Create(newStudent);

            return CreatedAtRoute("GetResourceStudents", new { id = newId }, entity);
        }
     */