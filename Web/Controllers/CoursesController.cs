using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        public CoursesController()
        {
            Courses = new CourseRepository();
            //            Courses.Create(new Course("Ionut", "Iacob", 3, "A5", DateTime.Now));
            //            Courses.Create(new Course("Anca", "Adascalitei", 3, "A5", DateTime.Now));
            //            Courses.Create(new Course("Stefan", "Gordin", 7, "A5", DateTime.Now));
            //            Courses.Create(new Course("Eveline", "Giosanu", 3, "A5", DateTime.Now));
            //            Courses.Create(new Course("Alexandra", "Gadioi", 3, "A2", DateTime.Now));
        }

        public CourseRepository Courses { get; set; }

        // GET api/Courses
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Courses.GetAll().Select(c => c.Title).ToArray();
        }

        // GET api/Courses/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return Courses.GetById(id).Title;
        }

        // POST api/Courses
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Courses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Courses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}