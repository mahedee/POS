using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POSMVC.Startup))]
namespace POSMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
