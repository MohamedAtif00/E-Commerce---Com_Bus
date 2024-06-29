using E_Commerce.Domain.Model.SuperCategoryAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.SuperCategoryConfig
{
    public class SuperCategoryConfiguration : IEntityTypeConfiguration<SuperCategory>
    {
        public void Configure(EntityTypeBuilder<SuperCategory> builder)
        {
            throw new NotImplementedException();
        }
    }
}
