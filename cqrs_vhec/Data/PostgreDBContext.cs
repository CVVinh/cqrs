using cqrs_vhec.Module.Postgre.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Data
{
    public class PostgreDBContext : DbContext
    {
        public PostgreDBContext(DbContextOptions<PostgreDBContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        
        public virtual DbSet<ProductPg> ProductPgs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
