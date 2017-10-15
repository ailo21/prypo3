using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prypo3.Startup))]
namespace prypo3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
