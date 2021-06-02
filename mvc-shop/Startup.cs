using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_shop.Startup))]
namespace mvc_shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
