using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DojoPuzzles.Startup))]
namespace DojoPuzzles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
