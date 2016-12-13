using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Data.AddStudents();
            Data.AddCourses();
            Data.AddTeachers();
            return Ok("Succesfully reset data.");
        }
    }
}
