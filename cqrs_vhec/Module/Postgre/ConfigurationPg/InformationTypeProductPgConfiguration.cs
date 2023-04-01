using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_vhec.Module.Postgre.Configuration
{
    public class InformationTypeProductPgConfiguration : IEntityTypeConfiguration<InformationTypeProductPg>
    {
        public void Configure(EntityTypeBuilder<InformationTypeProductPg> builder)
        {
            builder.ToTable("InformationTypeProduct", "public");

            builder.HasKey(e => new
            {
                e.InformationProductPgId,
                e.TypeProductPgId
            });
            builder.Property(e => e.InformationProductPgId).IsRequired();
            builder.Property(e => e.TypeProductPgId).IsRequired();

            builder
               .HasOne(e => e.InformationProductPg)
               .WithMany(y => y.InformationTypeProductPg)
               .HasPrincipalKey(w => w.Id)
               .HasForeignKey(z => z.InformationProductPgId)
               .HasConstraintName("FK_InfoPro_InfoTypePro")
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.TypeProductPg)
               .WithMany(y => y.InformationTypeProductPg)
               .HasPrincipalKey(w => w.Id)
               .HasForeignKey(z => z.TypeProductPgId)
               .HasConstraintName("FK_TypePro_InfoTypePro")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
