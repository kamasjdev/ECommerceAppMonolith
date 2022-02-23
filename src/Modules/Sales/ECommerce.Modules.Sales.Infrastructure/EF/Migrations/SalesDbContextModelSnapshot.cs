﻿// <auto-generated />
using System;
using ECommerce.Modules.Sales.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerce.Modules.Sales.Infrastructure.EF.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    partial class SalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sales")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.ItemSales.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("ImagesUrl")
                        .HasColumnType("text");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Items", "sales");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.ItemSales.Entities.ItemSale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Cost")
                        .HasPrecision(14, 4)
                        .HasColumnType("numeric(14,4)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("ItemSales", "sales");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Orders.Entities.ItemCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Cost")
                        .HasPrecision(14, 4)
                        .HasColumnType("numeric(14,4)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("ImagesUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ItemCarts", "sales");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Orders.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasPrecision(14, 4)
                        .HasColumnType("numeric(14,4)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumber")
                        .IsUnique();

                    b.ToTable("Orders", "sales");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Orders.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemCartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ItemCartId")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems", "sales");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Payments.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PaymentNumber")
                        .IsUnique();

                    b.ToTable("Payments", "sales");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.ItemSales.Entities.ItemSale", b =>
                {
                    b.HasOne("ECommerce.Modules.Sales.Domain.ItemSales.Entities.Item", "Item")
                        .WithOne("ItemSale")
                        .HasForeignKey("ECommerce.Modules.Sales.Domain.ItemSales.Entities.ItemSale", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Orders.Entities.OrderItem", b =>
                {
                    b.HasOne("ECommerce.Modules.Sales.Domain.Orders.Entities.ItemCart", "ItemCart")
                        .WithOne("OrderItem")
                        .HasForeignKey("ECommerce.Modules.Sales.Domain.Orders.Entities.OrderItem", "ItemCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Modules.Sales.Domain.Orders.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCart");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Payments.Entities.Payment", b =>
                {
                    b.HasOne("ECommerce.Modules.Sales.Domain.Orders.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.ItemSales.Entities.Item", b =>
                {
                    b.Navigation("ItemSale");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Orders.Entities.ItemCart", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("ECommerce.Modules.Sales.Domain.Orders.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
