using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Data;

namespace Movie.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<MasterActor> Actors { get; set; }
        public virtual DbSet<MasterMovie> Movies { get; set; }
        public virtual DbSet<MasterProducer> Producers { get; set; }
        public virtual DbSet<MasterMapMovie> MasterMovies { get; set; }

    }
}
