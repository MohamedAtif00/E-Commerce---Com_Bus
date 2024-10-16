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
        public Order(OrderId id, Address address, string customerName, string phoneNumber, CustomerId? customerId, decimal totalPrice,CouponId couponId = null) : base(id)
        {
            _customerId = customerId;
            Address = address;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            TotalPrice = totalPrice;
            CouponId = couponId;
            CreatedDate = DateTime.UtcNow;
        }
        [EnumDataType(typeof(OrderState))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderState State { get; set; } = OrderState.Pending;
        public DateTime CreatedDate { get; init; }
        public Address Address { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string? TrackingNumber { get; set; }
        public int Check { get; set; } = 0;
        public CustomerId? _customerId { get; init; }
        public CouponId? CouponId { get; set; }
        public Coupon Coupon { get; set; }
        
        public IReadOnlyCollection<OrderItem> _orderItems => orderItems;

        public static Order Create(CustomerId? customerId, Address address, string customerName, string phoneNumber,decimal totalPrice,CouponId couponId = null)
        {
            return new(OrderId.CreateUnique(),address,customerName,phoneNumber, customerId,totalPrice,couponId);
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

        public void AddTrackingNumber(string trackingNumber)
        {
            TrackingNumber = trackingNumber;    
        }

        public void MakeCheck()
        {
            Check++;
        }
        
    }

   [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderState
        {
            Pending,

            [Display(Name = "Pickup Requested")]
            PickupRequested,

            [Display(Name = "Waiting for route")]
            WaitingForRoute,

            [Display(Name = "Route Assigned")]
            RouteAssigned,

            [Display(Name = "Picked up from business")]
            PickedUpFromBusiness,

            [Display(Name = "Picking up from consignee")]
            PickingUpFromConsignee,

            [Display(Name = "Picked up from consignee")]
            PickedUpFromConsignee,

            [Display(Name = "Received at warehouse")]
            ReceivedAtWarehouse,

            Fulfilled,

            [Display(Name = "In transit between Hubs")]
            InTransitBetweenHubs,

            [Display(Name = "Picking up")]
            PickingUp,

            [Display(Name = "Picked up")]
            PickedUp,

            [Display(Name = "Pending Customer Signature")]
            PendingCustomerSignature,

            [Display(Name = "Debriefed Successfully")]
            DebriefedSuccessfully,

            Delivered,

            [Display(Name = "Returned to business")]
            ReturnedToBusiness,

            Exception,

            Terminated,

            [Display(Name = "Canceled (uncovered area)")]
            CanceledUncoveredArea,

            [Display(Name = "Collection Failed")]
            CollectionFailed,

            [Display(Name = "Returned to stock")]
            ReturnedToStock,

            Lost,

            Damaged,

            Investigation,

            [Display(Name = "Awaiting your action")]
            AwaitingYourAction,

            Archived,

            [Display(Name = "On hold")]
            OnHold,

            Failed,

            Cancelled,

            Delivering
        }


}
