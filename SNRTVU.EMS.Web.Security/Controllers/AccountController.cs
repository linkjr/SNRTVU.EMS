using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.Web.Security.Controllers
{
    public class AccountController : AdminController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
            : base(userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return Redirect(FormsAuthentication.DefaultUrl);
                else
                    return Redirect(returnUrl);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(LoginTransferObject dataObject, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(dataObject);
            }

            this._userService.Login(dataObject);
            FormsAuthentication.SetAuthCookie(dataObject.Account, false);

            if (Request.IsAjaxRequest())
                return Json(new { result = true, msg = "登录成功。", url = returnUrl ?? FormsAuthentication.DefaultUrl });
            else
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return Redirect(FormsAuthentication.DefaultUrl);
                else
                    return Redirect(returnUrl);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            base.CurrentUser = null;
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}