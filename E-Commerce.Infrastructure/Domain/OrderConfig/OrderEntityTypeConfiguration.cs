using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.OrderConfig
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>OrderId.Create(x));

            builder.Property(x => x._customerId).HasConversion(x =>x.value,x =>CustomerId.Create(x));

            builder.Property(x => x.State).HasColumnType("nvarchar(10)"); ;
                
            builder.OwnsMany(x => x._orderItems,conf => 
            {
                conf.WithOwner(x => x._order).HasForeignKey(x =>x._orderId);

                conf.HasKey(x => x.Id);
                conf.Property(x => x.Id).HasConversion(x =>x.value,x =>OrderItemId.Create(x));

                conf.Property(x => x._orderId).HasConversion(x =>x.value,x =>OrderId.Create(x));

                conf.Property(x =>x._productId).HasConversion(x =>x.value,x =>ProductId.Create(x));
            });

            builder.ComplexProperty(x =>x.Address,a => 
            {
                a.Property(a => a.street)
                .IsRequired()
                .HasColumnName("Address_Street");

                a.Property(a => a.city).IsRequired().HasColumnName("Address_City");
                a.Property(a => a.state).IsRequired().HasColumnName("Address_State");
            });
        }
    }
}
