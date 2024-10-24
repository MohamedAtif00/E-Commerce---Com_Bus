﻿// <auto-generated />
using System;
using System.Collections.Generic;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240716200254_make-updatedA-nullable-to-image")]
    partial class makeupdatedAnullabletoimage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce.Domain.Model.CategoryAggre.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SuperCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("_parentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("_visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SuperCategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.CustomerAggre.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.OrderAggre.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("_customerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.ProductAggre.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("_CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 7, 16, 23, 2, 54, 435, DateTimeKind.Local).AddTicks(7310));

                    b.Property<DateTime?>("_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("_stockQuantity")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("_price", "E_Commerce.Domain.Model.ProductAggre.Product._price#Price", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int?>("_discount")
                                .HasColumnType("int")
                                .HasColumnName("Price_discount");

                            b1.Property<decimal>("_price")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Price_price");

                            b1.Property<decimal?>("_total")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Price_total");
                        });

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.ProductOptionAggre.ProductOption", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("_optionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("_productId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("productsOption");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.ReviewAggre.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("_customerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.SpecificationAggre.Options", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("specificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("specificationId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.SpecificationAggre.Specification", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("specifications");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.SuperCategoryAggre.SuperCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("superCategories");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.CategoryAggre.Category", b =>
                {
                    b.HasOne("E_Commerce.Domain.Model.CategoryAggre.Category", null)
                        .WithMany("ChildCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("E_Commerce.Domain.Model.SuperCategoryAggre.SuperCategory", null)
                        .WithMany("categories")
                        .HasForeignKey("SuperCategoryId");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.OrderAggre.Order", b =>
                {
                    b.OwnsMany("E_Commerce.Domain.Model.OrderAggre.OrderItem", "_orderItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("_orderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("_productId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("_quantity")
                                .HasColumnType("int");

                            b1.Property<decimal>("_total")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("Id");

                            b1.HasIndex("_orderId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner("_order")
                                .HasForeignKey("_orderId");

                            b1.Navigation("_order");
                        });

                    b.Navigation("_orderItems");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.ProductAggre.Product", b =>
                {
                    b.OwnsMany("E_Commerce.Domain.Model.ProductAggre.Image", "images", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsMaster")
                                .HasColumnType("bit");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("Image");

                            b1.WithOwner("Product")
                                .HasForeignKey("ProductId");

                            b1.Navigation("Product");
                        });

                    b.Navigation("images");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.ReviewAggre.Review", b =>
                {
                    b.OwnsOne("E_Commerce.Domain.Model.ReviewAggre.Rating", "rating", b1 =>
                        {
                            b1.Property<Guid>("ReviewId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("ReviewId");

                            b1.ToTable("Review");

                            b1.WithOwner()
                                .HasForeignKey("ReviewId");
                        });

                    b.Navigation("rating")
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.SpecificationAggre.Options", b =>
                {
                    b.HasOne("E_Commerce.Domain.Model.SpecificationAggre.Specification", null)
                        .WithMany("options")
                        .HasForeignKey("specificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.CategoryAggre.Category", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.SpecificationAggre.Specification", b =>
                {
                    b.Navigation("options");
                });

            modelBuilder.Entity("E_Commerce.Domain.Model.SuperCategoryAggre.SuperCategory", b =>
                {
                    b.Navigation("categories");
                });
#pragma warning restore 612, 618
        }
    }
}
