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
        public virtual DbSet<TypeProductPg> TypeProductPgs { get; set; }
        public virtual DbSet<ProductImgPg> ProductImgPgs { get; set; }
        public virtual DbSet<InformationProductPg> InformationProductPgs { get; set; }
        public virtual DbSet<InformationTypeProductPg> InformationTypeProductPgs { get; set; }
        public virtual DbSet<DetailInformationTypeProductPg> DetailInformationTypeProductPgs { get; set; }


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
