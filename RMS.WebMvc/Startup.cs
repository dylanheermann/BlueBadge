using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RMS.WebMvc.Startup))]
namespace RMS.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
