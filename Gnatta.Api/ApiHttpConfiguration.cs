using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;

namespace Gnatta.Api
{
    public class ApiHttpConfiguration : HttpConfiguration
    {
        public ApiHttpConfiguration(ILifetimeScope container)
        {
            DependencyResolver = new AutofacWebApiDependencyResolver(container);
            Formatters.Remove(Formatters.XmlFormatter);
            Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            this.MapHttpAttributeRoutes();
        }
    }
}