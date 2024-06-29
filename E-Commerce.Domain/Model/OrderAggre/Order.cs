using E_Commerce.Domain.Model.CustomerAggre;
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
        private readonly List<OrderItem> orderItems = new();
        public Order(OrderId id,CustomerId customerId) : base(id)
        {
        }

        public DateTime CreatedDate { get; init; } = DateTime.Now;
        public CustomerId _customerId { get; init; }
        public IReadOnlyCollection<OrderItem> _orderItems => orderItems.AsReadOnly();

        public static Order Create(CustomerId customerId)
        {
            return new(OrderId.CreateUnique(),customerId);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
        }

        public void AddRangeOrderItem(List<OrderItem> orderItems)
        {
            this.orderItems.AddRange(orderItems);
        }
    }
}
