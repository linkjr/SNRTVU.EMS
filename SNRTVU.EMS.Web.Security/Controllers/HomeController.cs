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
        private readonly IAccountFeeService _accountFeeService;

        public HomeController(IUserService userService, IStudentService studentService, IAccountFeeService accountFeeService)
            : base(userService, studentService)
        {
            this._userService = userService;
            this._studentService = studentService;
            this._accountFeeService = accountFeeService;
        }

        public ActionResult Index()
        {
            var ar = base.CurrentUser;
            return View(ar);
        }

        public ActionResult Fee()
        {
            var list = this._accountFeeService.GetList(base.StuID);
            return View(list);
        }
    }
}