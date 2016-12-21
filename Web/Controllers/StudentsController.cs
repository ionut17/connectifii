using System;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
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
    }
}