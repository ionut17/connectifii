using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        public StudentsController()
        {
            Students = new StudentRepository();
            Students.Create(new Student("Ionut", "Iacob", 3, "A5", DateTime.Now));
            Students.Create(new Student("Anca", "Adascalitei", 3, "A5", DateTime.Now));
            Students.Create(new Student("Stefan", "Gordin", 7, "A5", DateTime.Now));
            Students.Create(new Student("Eveline", "Giosanu", 3, "A5", DateTime.Now));
            Students.Create(new Student("Alexandra", "Gadioi", 3, "A2", DateTime.Now));
        }

        public StudentRepository Students { get; set; }

        // GET api/students
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Students.GetAll().Select(s => s.FirstName).ToArray();
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/students
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}