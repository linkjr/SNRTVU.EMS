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
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;

        public AdminController(IUserService userService, IStudentService studentService)
        {
            this._userService = userService;
            this._studentService = studentService;
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

        public string StuID
        {
            get
            {
                if (Session["StuID"] == null)
                {
                    var studentList = this._studentService.FindListByIdentification(this.CurrentUser.Identification);
                    if (studentList != null && studentList.Any())
                    {
                        return studentList.ToList()[0].StuID;
                    }
                }
                return null;
            }
        }
    }
}