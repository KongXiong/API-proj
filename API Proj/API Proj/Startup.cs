using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(API_Proj.Startup))]
namespace API_Proj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
