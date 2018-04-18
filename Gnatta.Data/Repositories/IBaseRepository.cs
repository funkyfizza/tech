using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gnatta.Data.Models;

namespace Gnatta.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Get(Guid id);
        Task<List<TEntity>> GetAll();
        Task InsertOrOverwrite(TEntity entity);
    }
}