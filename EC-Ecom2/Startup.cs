using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EC_Ecom2.Startup))]
namespace EC_Ecom2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
					// Adding a comment
            ConfigureAuth(app);
        }
    }
}
