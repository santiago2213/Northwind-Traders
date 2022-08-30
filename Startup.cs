using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Santiago_HW3.Startup))]
namespace Santiago_HW3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
