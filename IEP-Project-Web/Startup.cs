using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IEP_Project_Web.Startup))]
namespace IEP_Project_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
