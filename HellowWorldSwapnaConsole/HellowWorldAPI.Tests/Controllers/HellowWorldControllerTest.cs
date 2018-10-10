using HellowWorldAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
namespace HellowWorldAPI.Tests.Controllers
{
    [TestClass]
    public class HellowWorldControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HelloWorldController controller = new HelloWorldController();

            // Act
            HttpResponseMessage result = controller.Index() as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
