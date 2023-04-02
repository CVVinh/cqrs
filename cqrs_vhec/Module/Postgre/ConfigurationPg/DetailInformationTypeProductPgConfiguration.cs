using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_vhec.Module.Postgre.Configuration
{
    public class DetailInformationTypeProductPgConfiguration : IEntityTypeConfiguration<DetailInformationTypeProductPg>
    {
        public void Configure(EntityTypeBuilder<DetailInformationTypeProductPg> builder)
        {
            builder.ToTable("DetailInformationTypeProduct", "public");
            builder.HasKey(e => e.Id);
            //builder.Property(e => e.Id).UseIdentityColumn();
            //builder.HasKey(e => new
            //{
            //    e.InformationTypeProductPgId,
            //    e.ProductPgId,
            //    e.Id
            //});
            builder.Property(e => e.InformationTypeProductPgId).IsRequired();
            builder.Property(e => e.ProductPgId).IsRequired();
            builder.Property(e => e.Content).HasColumnType("text");

            builder
               .HasOne(e => e.InformationTypeProductPg)
               .WithMany(y => y.DetailInformationTypeProductPg)
               .HasPrincipalKey(w => w.Id)
               .HasForeignKey(z => z.InformationTypeProductPgId)
               .HasConstraintName("FK_InfoTypePro_DetailInfoTypePro")
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.ProductPg)
               .WithMany(y => y.DetailInformationTypeProductPg)
               .HasPrincipalKey(w => w.Id)
               .HasForeignKey(z => z.ProductPgId)
               .HasConstraintName("FK_Pro_DetailPro")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
