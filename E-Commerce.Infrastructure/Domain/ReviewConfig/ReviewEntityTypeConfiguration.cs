using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ReviewAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ReviewConfig
{
    public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>ReviewId.Create(x));
            builder.Property(x => x._customerId).HasConversion(x=>x.value,x =>CustomerId.Create(x));
            builder.Property(x =>x.productId).HasConversion(x =>x.value,x =>ProductId.Create(x));

            builder.OwnsOne(x => x.rating);
        }
    }
}
