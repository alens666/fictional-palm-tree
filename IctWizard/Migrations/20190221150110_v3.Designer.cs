﻿// <auto-generated />
using System;
using IctWizard.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IctWizard.Migrations
{
    [DbContext(typeof(IctContext))]
    [Migration("20190221150110_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IctWizard.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("IctWizard.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<int>("ProductPrice");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IctWizard.Models.ProductPart", b =>
                {
                    b.Property<int>("PartId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("PartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductParts");
                });

            modelBuilder.Entity("IctWizard.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("IctWizard.Models.SupplierPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartId");

                    b.Property<int>("Quantity");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SupplierParts");
                });

            modelBuilder.Entity("IctWizard.Models.ProductPart", b =>
                {
                    b.HasOne("IctWizard.Models.Part", "Part")
                        .WithMany("ProductParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IctWizard.Models.Product", "Product")
                        .WithMany("ProductParts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IctWizard.Models.SupplierPart", b =>
                {
                    b.HasOne("IctWizard.Models.Part", "Part")
                        .WithMany("SupplierParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IctWizard.Models.Supplier", "Supplier")
                        .WithMany("SupplierParts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
