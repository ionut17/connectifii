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
//            Teachers.Create(new Teacher("Ionut", "Iacob", 3, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Anca", "Adascalitei", 3, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Stefan", "Gordin", 7, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Eveline", "Giosanu", 3, "A5", DateTime.Now));
//            Teachers.Create(new Teacher("Alexandra", "Gadioi", 3, "A2", DateTime.Now));
        }
    }
}