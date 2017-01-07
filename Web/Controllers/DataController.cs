using Microsoft.AspNetCore.Mvc;
using Web.DummyData;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        [HttpGet]
        public IActionResult ResetDataBase()
        {
            Data.AddCourses();
            Data.AddTeachers();
            //Data.AddGroups();
            Data.AddStudents();
            return Ok("Succesfully reset data.");
        }
    }
}