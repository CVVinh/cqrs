using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_vhec.Module.Postgre.Configuration
{
    public class ProductPgConfiguration : IEntityTypeConfiguration<ProductPg>
    {
        public void Configure(EntityTypeBuilder<ProductPg> builder)
        {
            builder.ToTable("Product", "public");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("varchar(255)");
            builder.Property(e => e.Description).HasColumnType("text");
            builder.Property(e => e.Quantity).HasDefaultValue(0);
            builder.Property(e => e.Price).HasDefaultValue(0);
            builder.Property(e => e.TypeProductPgId).IsRequired();

            builder
               .HasOne(e => e.TypeProductPg)
               .WithMany(y => y.ProductPg)
               .HasPrincipalKey(w => w.Id)
               .HasForeignKey(z => z.TypeProductPgId)
               .HasConstraintName("FK_TypePro_Pro")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
