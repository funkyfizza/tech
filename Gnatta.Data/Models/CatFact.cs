using System;
using System.Collections.Generic;

namespace Gnatta.Data.Models
{
    public class CatFact : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Fact { get; set; }
        public IList<CatFactComment> Comments { get; set; } = new List<CatFactComment>();
        public IList<CatFactRating> Ratings { get; set; } = new List<CatFactRating>();
    }
}