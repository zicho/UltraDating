using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UltraDatingHT17.Startup))]
namespace UltraDatingHT17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
