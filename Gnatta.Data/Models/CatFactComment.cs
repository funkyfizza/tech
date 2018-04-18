using System;

namespace Gnatta.Data.Models
{
    public class CatFactComment
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Comment { get; set; }
    }
}