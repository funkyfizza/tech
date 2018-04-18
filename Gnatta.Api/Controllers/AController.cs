using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gnatta.Data.Autofac;
using Gnatta.Data.Models;
using Gnatta.Data.Repositories;
using Newtonsoft.Json;

namespace Gnatta.Api.Controllers
{
    [RoutePrefix("api/upload")]
    public class AController : ApiController
    {
        public ICatFactRepository Thing { get; set; }

        public AController(ICatFactRepository thing)
        {
            Thing = thing;
        }
        
        [HttpPost, Route("")]
        public IHttpActionResult Go()
        {
            Go2();
            return Ok();
        }

        public void Go2()
        {
            using (var thing = new HttpClient())
            {
                var result = thing.GetAsync("https://catfact.ninja/facts?limit=1").Result;
                foreach (var c in ((IEnumerable<dynamic>) JsonConvert.DeserializeObject<dynamic>(result.Content.ReadAsStringAsync().Result)["data"]).Select(cf => new CatFact { Comments = new List<CatFactComment>(), Fact = cf.fact.ToString(), Timestamp = DateTime.Now, Id = Guid.NewGuid() }))
                {
                    Thing.InsertOrOverwrite(c);
                }
            }
        }
    }
}