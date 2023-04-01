using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_vhec.Module.Postgre.Configuration
{
    public class InformationProductPgConfiguration : IEntityTypeConfiguration<InformationProductPg>
    {
        public void Configure(EntityTypeBuilder<InformationProductPg> builder)
        {
            builder.ToTable("InformationProduct", "public");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("varchar(255)");
            builder.Property(e => e.Description).HasColumnType("text");
        }
    }
}
