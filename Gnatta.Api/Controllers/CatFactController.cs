using System;
using System.Threading.Tasks;
using System.Web.Http;
using Gnatta.Data.Models;
using Gnatta.Data.Repositories;

namespace Gnatta.Api.Controllers
{
    [RoutePrefix("api/fact")]
    public class CatFactController : ApiController
    {
        private readonly ICatFactRepository _repository;

        public CatFactController(ICatFactRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet, Route("")]
        public async Task<IHttpActionResult> List()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpDelete, Route("")]
        public async Task<IHttpActionResult> DeleteAll()
        {
            await _repository.DeleteAll();
            return Ok();
        }

        [HttpPost, Route("{id:guid}/comment")]
        public async Task<IHttpActionResult> AddComment(Guid id, [FromBody]string commentText)
        {
            var comment = new CatFactComment
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Comment = commentText
            };
            
            await _repository.AddComment(id, comment);
            return Ok(comment);
        }

        [HttpPost, Route("{id:guid}/rating")]
        public async Task<IHttpActionResult> AddRating(Guid id, [FromBody]int ratingValue)
        {
            var rating = new CatFactRating
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Rating = ratingValue
            };
            
            await _repository.AddRating(id, rating);
            return Ok(rating);
        }
    }
}