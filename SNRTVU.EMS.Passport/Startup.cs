using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNRTVU.EMS.Passport.Startup))]
namespace SNRTVU.EMS.Passport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
