using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_vhec.Module.Postgre.Configuration
{
    public class ProductImgPgConfiguration : IEntityTypeConfiguration<ProductImgPg>
    {
        public void Configure(EntityTypeBuilder<ProductImgPg> builder)
        {
            builder.ToTable("ProductImg", "public");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.ImgPath).HasColumnType("text");
            builder.Property(e => e.ProductPgId).IsRequired();

            builder
               .HasOne(e => e.ProductPg)
               .WithMany(y => y.ProductImgPg)
               .HasPrincipalKey(w => w.Id)
               .HasForeignKey(z => z.ProductPgId)
               .HasConstraintName("FK_Pro_ProImg")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
