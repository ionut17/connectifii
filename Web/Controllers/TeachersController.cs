using System.Linq;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class TeachersController : AbstractController<Teacher>
    {
        public TeachersController()
        {
            Repository = new TeacherRepository();
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null)
                return BadRequest();

            var teacher = new Teacher(teacherDto);

            if (
                Repository.GetAll()
                    .Any(
                        t =>
                            t.LastName.Equals(teacher.LastName) && t.FirstName.Equals(teacher.FirstName) &&
                            (t.BirthDate == teacher.BirthDate)))
                return BadRequest("Teacher already in DB.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Create(teacher);
            return CreatedAtRoute("GetResourceteachers", new {id = teacher.Id}, teacher);
        }
    }
}