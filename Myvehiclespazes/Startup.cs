using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myvehiclespazes.Startup))]
namespace Myvehiclespazes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
