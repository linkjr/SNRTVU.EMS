using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SNRTVU.EMS.IApplication;
using SNRTVU.EMS.TransferObjects;

namespace SNRTVU.EMS.Web.Security
{
    [Authorize]
    public class AdminController : BaseController
    {
        private IUserService _userService;

        public AdminController(IUserService userService)
        {
            this._userService = userService;
        }

        public AccountTransferObject CurrentUser
        {
            get
            {
                if (Session["User"] == null)
                {
                    if (base.User.Identity == null || string.IsNullOrEmpty(base.User.Identity.Name))
                        return null;
                    else
                    {
                        var account = base.User.Identity.Name;
                        Session["User"] = this._userService.FindByAccount(base.User.Identity.Name);
                    }
                }
                return (AccountTransferObject)Session["User"];
            }
            set
            {
                Session["User"] = value;
            }
        }
    }
}