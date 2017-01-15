using System;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/students")]
    public class StudentsController : AbstractController<Student>
    {
        private readonly IMapper Mapper;
        public StudentRepository StudentRepository = new StudentRepository();

        public StudentsController(IMapper mapper)
        {
            Repository = new StudentRepository();
            Mapper = mapper;
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
            return Ok(result);
        }

        [HttpGet("{registrationNumber}/courses/{courseId}")]
        public IActionResult GetCourse(string registrationNumber, Guid courseId)
        {
            var result = StudentRepository.GetByRegistrationNumber(registrationNumber);
            if (result == null)
                return NotFound("Registration number " + registrationNumber + " does not exist");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDto entity)
        {
            if (entity == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //TODO solve conflict at inserting group (not allowing null)

            var newStudent = Mapper.Map<StudentDto, Student>(entity);
            newStudent.Id = new Guid();

            StudentRepository.Create(newStudent);

            return CreatedAtRoute("GetResourcestudents", new {id = newStudent.Id}, entity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] StudentDto entity)
        {
            if (entity == null)
                return BadRequest();

            var newStudent = Mapper.Map<StudentDto, Student>(entity);
            newStudent.Id = id;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentRepository.Update(newStudent);
            return new NoContentResult();
        }
    }
}