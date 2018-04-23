using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gnatta.Data.Models;
using Gnatta.Data.Repositories;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using static System.Threading.Tasks.Task;

namespace Gnatta.Api.Test
{
    [TestFixture]
    public class CatFactDownloadTests
    {
        [Test]
        public void test()
        {
            //arange
            var catFacts = new List<CatFact>
            {
                new CatFact
                {
                    Comments=new List<CatFactComment>()
                    ,Fact="fact1"
                    ,Id=Guid.NewGuid()
                    ,Ratings=new List<CatFactRating>()
                    ,Timestamp = DateTime.Now
                }
                ,
                new CatFact
                {
                    Comments=new List<CatFactComment>()
                    ,Fact="fact2"
                    ,Id=Guid.NewGuid()
                    ,Ratings=new List<CatFactRating>()
                    ,Timestamp = DateTime.Now
                }
            };

            //mocked mongo items
            var mockedMongoDb = new Mock<IMongoDatabase>();
            var mockedMongoCollection = new Mock<IMongoCollection<CatFact>>();
            
            //Setup te collection
            mockedMongoCollection.Object.InsertMany(catFacts);

            //setup the call to return that collection
            mockedMongoDb.Setup(database => database.GetCollection<CatFact>(typeof(CatFact).Name,null)
                         ).Returns(mockedMongoCollection.Object); ;


            //act - pass in the mocked db with data as setup above
            var catFactrepository=new CatFactRepository(mockedMongoDb.Object);



            var items= catFactrepository.GetAll();


        }

    }
}