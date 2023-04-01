using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_vhec.Module.Postgre.Configuration
{
    public class TypeProductPgConfiguration : IEntityTypeConfiguration<TypeProductPg>
    {
        public void Configure(EntityTypeBuilder<TypeProductPg> builder)
        {
            builder.ToTable("TypeProduct", "public");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("varchar(255)");

        }
    }
}
