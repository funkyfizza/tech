using System;
using System.Threading.Tasks;
using Gnatta.Data.Models;

namespace Gnatta.Data.Repositories
{
    public interface ICatFactRepository : IBaseRepository<CatFact>
    {
        Task DeleteAll();
        Task AddComment(Guid id, CatFactComment comment);
        Task AddRating(Guid id, CatFactRating rating);
    }
}