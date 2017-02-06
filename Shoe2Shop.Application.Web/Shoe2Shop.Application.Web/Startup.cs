using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shoe2Shop.Application.Web.Startup))]
namespace Shoe2Shop.Application.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
