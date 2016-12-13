using System;
using System.Collections.Generic;
using System.Linq;
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