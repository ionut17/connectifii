using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        public TeachersController()
        {
            Teachers = new TeacherRepository();
//            Teachers.Create(new Teacher("Ionut", "Iacob", 3, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Anca", "Adascalitei", 3, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Stefan", "Gordin", 7, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Eveline", "Giosanu", 3, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Alexandra", "Gadioi", 3, "A2", DateTime.Now));
        }

        public TeacherRepository Teachers { get; set; }

        // GET api/Teachers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Teachers.GetAll().Select(s => s.FirstName).ToArray();
        }

        // GET api/Teachers/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return Teachers.GetById(id).FirstName;
        }

        // POST api/Teachers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Teachers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Teachers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}