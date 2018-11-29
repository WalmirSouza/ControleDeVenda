using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MPSC.PlenoSoft.PlenoControle.WebApp.Startup))]
namespace MPSC.PlenoSoft.PlenoControle.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
