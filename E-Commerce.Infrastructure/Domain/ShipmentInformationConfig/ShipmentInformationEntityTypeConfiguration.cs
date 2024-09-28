using E_Commerce.Domain.Model.ShipmentInformationAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ShipmentInformationConfig
{
    public class ShipmentInformationEntityTypeConfiguration : IEntityTypeConfiguration<ShipmentInformation>
    {
        public void Configure(EntityTypeBuilder<ShipmentInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value,value => ShipmentInformationId.Create(value));

            builder.OwnsMany(x => x.pickupAddresses, p => {
                p.WithOwner(x => x.ShipmentInformation);
                p.HasKey(x => x.Id);
                p.Property(x => x.Id).HasConversion(x => x.value,value=> PickAddressId.Create(value));
                p.Property(x => x.ShipmentInformationId).HasConversion(x => x.value,x => ShipmentInformationId.Create(x));

            });
        }
    }
}
