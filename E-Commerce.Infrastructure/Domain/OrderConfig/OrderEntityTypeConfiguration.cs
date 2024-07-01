using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.OwnsMany(x => x._orderItems,conf => 
            {
                conf.WithOwner(x => x._order).HasForeignKey(x =>x._orderId);

                conf.HasKey(x => x.Id);
                conf.Property(x => x.Id).HasConversion(x =>x.value,x =>OrderItemId.Create(x));

                conf.Property(x => x._orderId).HasConversion(x =>x.value,x =>OrderId.Create(x));

                conf.Property(x =>x._productId).HasConversion(x =>x.value,x =>ProductId.Create(x));
            });
        }
    }
}
