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
            Data.AddToDatabase();
            return Ok("Succesfully reset data.");
        }
    }
}