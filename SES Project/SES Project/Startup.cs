using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SES_Project.Startup))]
namespace SES_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
