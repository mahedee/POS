using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuickBook.Startup))]
namespace QuickBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
