using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class OrderItem : Entity<OrderItemId>
    {
        public OrderItem(OrderItemId id, ProductId productId, int quantity, decimal total, OrderId? orderId = null) : base(id)
        {
            _productId = productId;
            _quantity = quantity;
            _total = total;
            _orderId = orderId;
        }

        public ProductId _productId { get;private set; }
        public int _quantity { get;private set; }
        public decimal _total { get;private set; }
        public OrderId? _orderId { get;private set; }
        public Order _order {  get;private set; }

        public static OrderItem Create(ProductId productId, int quantity, decimal total, OrderId? orderId = null)
        {
            return new(OrderItemId.CreateUnique(),productId,quantity,total,orderId);
        }

    }
}
