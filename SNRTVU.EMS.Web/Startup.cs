using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNRTVU.EMS.Web.Startup))]
namespace SNRTVU.EMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
