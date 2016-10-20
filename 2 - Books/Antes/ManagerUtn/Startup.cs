using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagerUtn.Startup))]
namespace ManagerUtn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
