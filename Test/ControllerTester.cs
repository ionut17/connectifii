using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;

namespace Test
{
    [TestClass]
    public class ControllerTester
    {
        [TestMethod]
        public void When_GetControllerData_Then_ReturnOkResult()
        {
            var controller = CreateSut();
            var result = controller.Get();
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        private static StudentsController CreateSut()
        {
            return new StudentsController();
        }
    }
}