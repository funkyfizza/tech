using System;
using System.Threading.Tasks;
using Gnatta.Data.Autofac;
using Gnatta.Data.Models;
using MongoDB.Driver;

namespace Gnatta.Data.Repositories
{
    public class CatFactRepository : BaseRepository<CatFact>, ICatFactRepository
    {
        public CatFactRepository(IMongoDatabase database) : base(database)
        {
        }

        public Task DeleteAll()
        {
            return Collection.DeleteManyAsync(x => true);
        }

        public Task AddComment(Guid id, CatFactComment comment)
        {
            return Collection.UpdateOneAsync(x => x.Id == id, UpdateBuilder.Push(x => x.Comments, comment));
        }

        public Task AddRating(Guid id, CatFactRating rating)
        {
            return Collection.UpdateOneAsync(x => x.Id == id, UpdateBuilder.Push(x => x.Ratings, rating));
        }
    }
}