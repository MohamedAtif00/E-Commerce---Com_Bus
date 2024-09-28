using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ShipmentAggre
{
    public class Shipment : AggregateRoot<ShipmentId>
    {
        public Shipment(ShipmentId id) : base(id)
        {
        }

        public string TrackingNumber  { get; set; }

    }
}
