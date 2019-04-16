using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSite.Startup))]
namespace JobSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
