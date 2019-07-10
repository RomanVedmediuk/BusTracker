namespace BusTracker.Infrastructure.Entities
{
    using System;

    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}