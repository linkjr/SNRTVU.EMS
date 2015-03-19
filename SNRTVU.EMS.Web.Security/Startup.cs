using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNRTVU.EMS.Web.Security.Startup))]
namespace SNRTVU.EMS.Web.Security
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
