using E_Commerce.Domain.Model.AdministrationAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.AdministrationConfig
{
    public class AdministrationEntityTypeConfiguration : IEntityTypeConfiguration<Administration>
    {
        public void Configure(EntityTypeBuilder<Administration> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x => AdministrationId.Create(x));

            builder.ComplexProperty(x => x._heroImage,c => 
            {

                c.Property(x=>x.Path).HasColumnName("Hero_Path").IsRequired(false);
            });

            builder.ComplexProperty(x => x._welcomeMessage,x => 
            {
                
            });

            builder.ComplexProperty(x => x._description);
        }
    }
}
