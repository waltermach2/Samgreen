using insurance.api.Models;
using insurance.api.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace insurance.api.Persistence
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        { }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<CoveringType> CoveringType { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    ModelConfig(builder);
        //}

        //private void ModelConfig(ModelBuilder modelBuilder)
        //{
        //    new PolicyConfiguration(modelBuilder.Entity<Policy>());
        //}
    }
}
