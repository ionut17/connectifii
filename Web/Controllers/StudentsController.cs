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
            ICollection<Course> empty = new List<Course>();
            Students.Create(new Student("001", "Ionut", "Iacob", 3, "A5", DateTime.Now, empty));
            Students.Create(new Student("002", "Anca", "Adascalitei", 3, "A5", DateTime.Now, empty));
            Students.Create(new Student("003", "Stefan", "Gordin", 7, "A5", DateTime.Now, empty));
            Students.Create(new Student("004", "Eveline", "Giosanu", 3, "A5", DateTime.Now, empty));
            Students.Create(new Student("005", "Alexandra", "Gadioi", 3, "A2", DateTime.Now, empty));
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
        public string Get(Guid id)
        {
            return Students.GetById(id).FirstName;
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