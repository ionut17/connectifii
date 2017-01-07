using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/students")]
    public class StudentsController : AbstractController<Student>
    {
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

        [HttpGet("{registrationNumber}/courses")]
        public IActionResult GetCourses(string registrationNumber)
        {
            var result = StudentRepository.GetByRegistrationNumber(registrationNumber);
            if (result == null)
                return NotFound("Registration number " + registrationNumber + " does not exist");
            return Ok(result.StudentCourses);
        }

        [HttpGet("{registrationNumber}/courses/{courseId}")]
        public IActionResult GetCourse(string registrationNumber, Guid courseId)
        {
            var result = StudentRepository.GetByRegistrationNumber(registrationNumber);
            if (result == null)
                return NotFound("Registration number " + registrationNumber + " does not exist");
            return Ok(result.StudentCourses.Select(sc => sc.Course).Where(c => c.Id == courseId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDTO entity)
        {
            if (entity == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            return CreatedAtRoute("GetResourceStudents", new { id = newId }, entity);
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
