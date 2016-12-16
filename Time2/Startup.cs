using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Time2.Startup))]
namespace Time2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
