using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gnatta.Data.Autofac;
using Gnatta.Data.Models;
using MongoDB.Driver;

namespace Gnatta.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
    {
        private readonly IMongoDatabase _database;
        
        protected readonly IMongoCollection<TEntity> Collection;
        protected readonly UpdateDefinitionBuilder<CatFact> UpdateBuilder;

        protected BaseRepository(IMongoDatabase database)
        {
            _database = database;
            Collection = GetCollection<TEntity>();

            UpdateBuilder = new UpdateDefinitionBuilder<CatFact>();
        }

        private IMongoCollection<TRequestedEntity> GetCollection<TRequestedEntity>()
        {
            return _database.GetCollection<TRequestedEntity>(typeof(TRequestedEntity).Name);
        }
        
        public Task<TEntity> Get(Guid id)
        {
            return Collection.Find(x => x.Id == id).FirstAsync();
        }

        public Task<List<TEntity>> GetAll()
        {
            return Collection.FindAsync(x => true).ContinueWith(x => x.Result.ToList());
        }

        public Task InsertOrOverwrite(TEntity entity)
        {
            return Collection.InsertOneAsync(entity);
        }
    }
}