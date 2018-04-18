using System;

namespace Gnatta.Data.Models
{
    public class CatFactRating
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int Rating { get; set; }
    }
}