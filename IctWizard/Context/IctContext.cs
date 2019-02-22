using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IctWizard.Models;

namespace IctWizard.Context
{
    public class IctContext : DbContext
    {
        public IctContext(DbContextOptions<IctContext> options)
            : base(options)
        {

        }

        public DbSet<Part> Parts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductPart> ProductParts { get; set; }
        public DbSet<SupplierPart> SupplierParts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPart>()
                .HasKey(p => new {p.PartId, p.ProductId});

            modelBuilder.Entity<SupplierPart>()
                .HasKey(s => new {s.SupplierId, s.PartId});

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductParts)
                .WithOne(x => x.Product);

            modelBuilder.Entity<Part>()
                .HasMany(p => p.ProductParts)
                .WithOne(x => x.Part);

            modelBuilder.Entity<Part>()
                .HasMany(p => p.SupplierParts)
                .WithOne(s => s.Part);

            modelBuilder.Entity<Supplier>()
                .HasMany(p => p.SupplierParts)
                .WithOne(x => x.Supplier);


        }
    }
}


