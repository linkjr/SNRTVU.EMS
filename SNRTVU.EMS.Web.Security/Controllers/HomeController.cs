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
        private IUserService _userService;

        public HomeController(IUserService userService)
            : base(userService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            var ar = base.CurrentUser;
            return View(ar);
        }
    }
}