using System;

namespace Gnatta.Data.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}