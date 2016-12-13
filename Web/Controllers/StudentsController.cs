using Core;
using Infrastructure;

namespace Web.Controllers
{
    public class StudentsController : AbstractController<Student>
    {
        public StudentsController()
        {
            Repository = new StudentRepository();
            
        }

    }
}