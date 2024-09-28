using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.OrderAggre.Events;
using E_Commerce.SharedKernal.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class Order : AggregateRoot<OrderId>
    {
        private readonly List<OrderItem> orderItems = new();

        public Order() : base(OrderId.CreateUnique())
        {
            
        }
        public Order(OrderId id, Address address, string customerName, string phoneNumber, CustomerId? customerId, decimal totalPrice,OrderState orderState = OrderState.Pending) : base(id)
        {
            _customerId = customerId;
            Address = address;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            TotalPrice = totalPrice;
            State = orderState;
        }
        [EnumDataType(typeof(OrderState))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderState State { get; set; } = OrderState.Pending;
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public Address Address { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public CustomerId? _customerId { get; init; }
        public IReadOnlyCollection<OrderItem> _orderItems => orderItems;

        public static Order Create(CustomerId? customerId, Address address, string customerName, string phoneNumber,decimal totalPrice)
        {
            return new(OrderId.CreateUnique(),address,customerName,phoneNumber, customerId,totalPrice);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _domainEvents.Add(new OrderItemCreatedDomainEvent(orderItem._productId,orderItem._quantity));
            orderItems.Add(orderItem);
        }

        public void AddRangeOrderItem(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                _domainEvents.Add(new OrderItemCreatedDomainEvent(item._productId,item._quantity));
            }
            this.orderItems.AddRange(orderItems);
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderState { 
        Pending,
        Accepted,
        Expired,
        Failed,
        Cancelled,
        Completed,
        Denied,
        Processing,
        Refunded,
        Delivered,
        Delivering
    }

}
