﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cqrs_vhec.Data;

#nullable disable

namespace cqrs_vhec.Migrations
{
    [DbContext(typeof(PostgreDBContext))]
    partial class PostgreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.DetailInformationTypeProductPg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("InformationTypeProductPgId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductPgId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InformationTypeProductPgId");

                    b.HasIndex("ProductPgId");

                    b.ToTable("DetailInformationTypeProduct", "public");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.InformationProductPg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("InformationProduct", "public");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.InformationTypeProductPg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InformationProductPgId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeProductPgId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InformationProductPgId");

                    b.HasIndex("TypeProductPgId");

                    b.ToTable("InformationTypeProduct", "public");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.ProductImgPg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductPgId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductPgId");

                    b.ToTable("ProductImg", "public");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.ProductPg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("TypeProductPgId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TypeProductPgId");

                    b.ToTable("Product", "public");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.TypeProductPg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TypeProduct", "public");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.DetailInformationTypeProductPg", b =>
                {
                    b.HasOne("cqrs_vhec.Module.Postgre.Entities.InformationTypeProductPg", "InformationTypeProductPg")
                        .WithMany("DetailInformationTypeProductPg")
                        .HasForeignKey("InformationTypeProductPgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_InfoTypePro_DetailInfoTypePro");

                    b.HasOne("cqrs_vhec.Module.Postgre.Entities.ProductPg", "ProductPg")
                        .WithMany("DetailInformationTypeProductPg")
                        .HasForeignKey("ProductPgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pro_DetailPro");

                    b.Navigation("InformationTypeProductPg");

                    b.Navigation("ProductPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.InformationTypeProductPg", b =>
                {
                    b.HasOne("cqrs_vhec.Module.Postgre.Entities.InformationProductPg", "InformationProductPg")
                        .WithMany("InformationTypeProductPg")
                        .HasForeignKey("InformationProductPgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_InfoPro_InfoTypePro");

                    b.HasOne("cqrs_vhec.Module.Postgre.Entities.TypeProductPg", "TypeProductPg")
                        .WithMany("InformationTypeProductPg")
                        .HasForeignKey("TypeProductPgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TypePro_InfoTypePro");

                    b.Navigation("InformationProductPg");

                    b.Navigation("TypeProductPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.ProductImgPg", b =>
                {
                    b.HasOne("cqrs_vhec.Module.Postgre.Entities.ProductPg", "ProductPg")
                        .WithMany("ProductImgPg")
                        .HasForeignKey("ProductPgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pro_ProImg");

                    b.Navigation("ProductPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.ProductPg", b =>
                {
                    b.HasOne("cqrs_vhec.Module.Postgre.Entities.TypeProductPg", "TypeProductPg")
                        .WithMany("ProductPg")
                        .HasForeignKey("TypeProductPgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TypePro_Pro");

                    b.Navigation("TypeProductPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.InformationProductPg", b =>
                {
                    b.Navigation("InformationTypeProductPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.InformationTypeProductPg", b =>
                {
                    b.Navigation("DetailInformationTypeProductPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.ProductPg", b =>
                {
                    b.Navigation("DetailInformationTypeProductPg");

                    b.Navigation("ProductImgPg");
                });

            modelBuilder.Entity("cqrs_vhec.Module.Postgre.Entities.TypeProductPg", b =>
                {
                    b.Navigation("InformationTypeProductPg");

                    b.Navigation("ProductPg");
                });
#pragma warning restore 612, 618
        }
    }
}
