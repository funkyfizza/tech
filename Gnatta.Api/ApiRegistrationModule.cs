using Autofac;
using Autofac.Integration.WebApi;
using Gnatta.Api.Services;
using Gnatta.Data.Autofac;
using Module = Autofac.Module;

namespace Gnatta.Api
{
    public class ApiRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register dependency modules
            builder.RegisterApiControllers(GetType().Assembly);
            builder.RegisterModule(new DataModule("mongodb://localhost/GnattaTest"));
            RegisterApiDependencies(builder);
            
            base.Load(builder);
        }

        private void RegisterApiDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<JsonNetSerialiser>().As<IJsonSerialiser>();
        }

        internal static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApiRegistrationModule>();
            return builder.Build();
        }
    }
}