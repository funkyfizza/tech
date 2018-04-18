using System.Web.Http;

namespace Gnatta.Api.Controllers
{
    [RoutePrefix("api/meta")]
    public class MetaController : ApiController
    {
        [HttpGet, Route("users")]
        public IHttpActionResult Users()
        {
            return Ok(new
            {
                list = new[]
                {
                    new { id = 1, name = "Bob" },
                    new { id = 2, name = "Barbara" },
                    new { id = 3, name = "Terrence" },
                    new { id = 4, name = "Timmy" },
                    new { id = 5, name = "Clyde" },
                    new { id = 6, name = "Frank" },
                }
            });
        }

        [HttpGet, Route("ratings")]
        public IHttpActionResult Ratings()
        {
            return Ok(new
            {
                list = new[]
                {
                    new { id = 1, userId = 1, rating = 5 },
                    new { id = 2, userId = 2, rating = 4 },
                    new { id = 3, userId = 4, rating = 5 },
                    new { id = 4, userId = 1, rating = 3 },
                    new { id = 5, userId = 1, rating = 3 },
                    new { id = 6, userId = 3, rating = 5 },
                    new { id = 7, userId = 5, rating = 2 },
                    new { id = 8, userId = 6, rating = 4 },
                    new { id = 9, userId = 2, rating = 4 },
                    new { id = 10, userId = 1, rating = 3 },
                    new { id = 11, userId = 3, rating = 3 },
                    new { id = 12, userId = 3, rating = 5 },
                    new { id = 13, userId = 1, rating = 4 },
                    new { id = 14, userId = 5, rating = 5 },
                    new { id = 15, userId = 6, rating = 4 },
                    new { id = 16, userId = 6, rating = 5 },
                    new { id = 17, userId = 5, rating = 3 },
                    new { id = 18, userId = 4, rating = 4 },
                    new { id = 19, userId = 4, rating = 5 },
                    new { id = 20, userId = 1, rating = 2 },
                    new { id = 21, userId = 2, rating = 3 },
                    new { id = 22, userId = 1, rating = 3 },
                    new { id = 23, userId = 1, rating = 5 },
                    new { id = 24, userId = 3, rating = 4 },
                    new { id = 25, userId = 3, rating = 5 },
                }
            });
        }
    }
}