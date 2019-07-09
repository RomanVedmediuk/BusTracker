using System;
using System.Collections.Generic;
using System.Text;

namespace BusStopsDataGrabber.Context
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class BusStopContext : DbContext
    {
        private readonly string connectionString;

        public BusStopContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                this.connectionString,
                x => x.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusStop>().HasKey(x => x.Id);
        }
    }
}
