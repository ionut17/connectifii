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
    }
}