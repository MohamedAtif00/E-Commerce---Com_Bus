﻿using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ProductAggre.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.productConfig
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>ProductId.Create(x));


            builder.Property(x => x._name)
                .IsRequired()
                .HasMaxLength(100); // Example: Set maximum length for name

            builder.Property(x => x._description)
                .IsRequired()
                .HasMaxLength(500); // Example: Set maximum length for description

            // Configure Price value object
            builder.ComplexProperty(
                x => x._price,
                price =>
                {
                    price.Property(p => p._price)
                        .HasColumnName("Price_price")
                        .HasColumnType("decimal(18,2)") // Example: Specify decimal precision
                        .IsRequired();

                    price.Property(p => p._discount)
                        .HasColumnName("Price_discount")
                        .HasColumnType("int"); // Example: Specify integer type for discount

                    price.Property(p => p._total)
                    .HasColumnName("Price_total");
                    // Optional: Ignore total property if not mapped
                    // price.Ignore(p => p._total);
                }
            );

            builder.Property(x => x._stockQuantity)
                .IsRequired();

            builder.Property(x => x._CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Now); // Example: Set default value for created date

            builder.Property(x => x._UpdatedAt)
                .IsRequired();

            // Optional: Configure other entity relationships, indexes, etc.
        }
    }
}