﻿using ECommerce.Modules.Items.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Items.Infrastructure.EF.DAL
{
    internal class ItemsDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Domain.Entities.Type> Types { get; set; }
        public DbSet<ItemSale> ItemSales { get; set; }

        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
        {
            // problem z UTC Date
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("items");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
