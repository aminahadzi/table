using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Coffee_Table.Startup))]
namespace Coffee_Table
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
