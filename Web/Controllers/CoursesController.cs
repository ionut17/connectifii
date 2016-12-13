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
        }
    }
}