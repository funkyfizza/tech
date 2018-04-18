using System.Net;
using Owin;

namespace Gnatta.Api
{
    public class ApiStartup
    {
        public void Configuration(IAppBuilder app)
        {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			
            app.UseWebApi(new ApiHttpConfiguration(ApiRegistrationModule.BuildContainer()));
        }
    }
}