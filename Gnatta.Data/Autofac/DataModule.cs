using Autofac;
using Gnatta.Data.Repositories;
using MongoDB.Driver;

namespace Gnatta.Data.Autofac
{
    public class DataModule : Module
    {
        private readonly string _mongoConnectionString;

        public DataModule(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            var url = MongoUrl.Create(_mongoConnectionString);
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);
            
            builder.RegisterInstance(db).As<IMongoDatabase>();
            builder.RegisterAssemblyTypes(typeof(DataModule).Assembly)
                .AsClosedTypesOf(typeof(IBaseRepository<>))
                .AsImplementedInterfaces()
                .AsSelf()
                .SingleInstance();
            
            base.Load(builder);
        }
    }
}