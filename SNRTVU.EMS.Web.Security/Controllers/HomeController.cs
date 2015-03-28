using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SNRTVU.EMS.IApplication;

namespace SNRTVU.EMS.Web.Security.Controllers
{
    public class HomeController : AdminController
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;

        public HomeController(IUserService userService, IStudentService studentService)
            : base(userService, studentService)
        {
            this._userService = userService;
            this._studentService = studentService;
        }

        public ActionResult Index()
        {
            var ar = base.CurrentUser;
            return View(ar);
        }
    }
}