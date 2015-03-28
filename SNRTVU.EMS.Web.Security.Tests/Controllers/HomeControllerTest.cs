using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SNRTVU.EMS.Application;
using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.Web.Security;
using SNRTVU.EMS.Web.Security.Controllers;

namespace SNRTVU.EMS.Web.Security.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly IUserService userService;
        private readonly IStudentService studentService;

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(userService, studentService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
