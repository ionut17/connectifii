using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : AbstractController<Course>
    {
        public CoursesController()
        {
            Repository = new CourseRepository();
            //            Courses.Create(new Course("Ionut", "Iacob", 3, "A5", DateTime.Now));
            //            Courses.Create(new Course("Anca", "Adascalitei", 3, "A5", DateTime.Now));
            //            Courses.Create(new Course("Stefan", "Gordin", 7, "A5", DateTime.Now));
            //            Courses.Create(new Course("Eveline", "Giosanu", 3, "A5", DateTime.Now));
            //            Courses.Create(new Course("Alexandra", "Gadioi", 3, "A2", DateTime.Now));
        }
    }
}