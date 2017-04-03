using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RCScustomer.Startup))]
namespace RCScustomer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
