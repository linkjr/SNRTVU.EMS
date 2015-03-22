using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.Web.Security.Controllers
{
    public class ManageController : AdminController
    {
        private IUserService _userService;

        public ManageController(IUserService userService)
            : base(userService)
        {
            this._userService = userService;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            base.CurrentUser = this._userService.FindByAccount(base.User.Identity.Name);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this._userService.ChangePassword(base.CurrentUser.ID, model.OldPassword, model.NewPassword);
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return Json(new { result = true, msg = "修改成功", url = Url.Action("index", "home") });
            }
        }

        public ActionResult ModifyProfile()
        {
            var model = new ModifyProfileViewModel
            {
                Account = base.CurrentUser.Account
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ModifyProfile(ModifyProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this._userService.ModifyProfile(base.CurrentUser.ID, model.Account);
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return Json(new { result = true, msg = "修改成功", url = Url.Action("index", "home") });
            }
        }

        public ActionResult ModifyContact()
        {
            var ar = base.CurrentUser;
            var model = new ContactTransferObject
            {
                Phone = ar.Phone,
                Province = ar.Province,
                City = ar.City,
                District = ar.District,
                Address = ar.Address,
                IsByPost = ar.IsByPost.HasValue ? ar.IsByPost.Value : false
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ModifyContact(ContactTransferObject model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.ID = base.CurrentUser.ID;
            this._userService.ModifyContact(model);
            if (!Request.IsAjaxRequest())
                return RedirectToAction("index", "home");
            else
            {
                return Json(new { result = true, msg = "修改成功", url = Url.Action("index", "home") });
            }
        }
    }
}