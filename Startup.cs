using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTask.Startup))]
namespace ProjectTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
