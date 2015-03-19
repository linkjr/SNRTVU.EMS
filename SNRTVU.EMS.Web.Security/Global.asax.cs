using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;

using SNRTVU.EMS.Infrastructure.Ioc;
using SNRTVU.EMS.Infrastructure.Mvc;

namespace SNRTVU.EMS.Web.Security
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ServiceLocator.Instance.Container.RegisterType<IControllerFactory, UnityControllerFactory>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(ServiceLocator.Instance.Container));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpStatusCode = exception is HttpException ? (exception as HttpException).GetHttpCode() : 500;
            var routeData = new RouteData();
            routeData.Values.Add("controller", "home");
            var model = new HandleErrorInfo(exception, routeData.Values["controller"].ToString(), "error");
            switch (httpStatusCode)
            {
                case 404:
                    routeData.Values.Add("action", "error");
                    break;
                default:
                    routeData.Values.Add("action", "error");
                    break;
            }
            Server.ClearError();
            var controller = new MasterController();
            controller.ViewData.Model = model;
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(this.Context), routeData));
        }

        //protected void Application_AuthenticateRequest()
        //{
        //    var claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimTypes.Name, "admin"));
        //    claims.Add(new Claim(ClaimTypes.Role, "Users"));
        //    var identity = new ClaimsIdentity(claims, Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
        //    var principal = new ClaimsPrincipal(identity);
        //    HttpContext.Current.User = principal;
        //}
    }
}
