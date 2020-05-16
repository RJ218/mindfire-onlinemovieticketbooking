using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ppl.Startup))]
namespace ppl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
