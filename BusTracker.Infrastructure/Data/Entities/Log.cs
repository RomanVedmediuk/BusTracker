namespace BusTracker.Infrastructure.Data.Entities
{
    using System;

    public abstract class Log
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}