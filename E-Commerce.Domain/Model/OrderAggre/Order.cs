using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class Order : AggregateRoot<OrderId>
    {
        public Order(OrderId id) : base(id)
        {
        }

        public DateTime CreatedDate { get; init; } = DateTime.Now;

    }
}
