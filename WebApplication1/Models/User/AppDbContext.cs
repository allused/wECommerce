﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wECommerce.Models.Store;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .Property(b => b.InStock)
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .Property(b => b.IsOnSale)
                .HasDefaultValue(false);

            modelBuilder.Entity<Category>()
                .Property(b => b.Description)
                .HasDefaultValue("Description was not provided for this category.");

            modelBuilder.Entity<CartItem>()
                .Property(b => b.Quantity)
                .HasDefaultValue();
        }
    }
}
