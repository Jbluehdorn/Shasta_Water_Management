using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shasta_Water_Management.Startup))]
namespace Shasta_Water_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
