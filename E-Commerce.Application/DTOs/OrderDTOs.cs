using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class OrderDTOs
    {
        public record OrderItemDTO(ProductId productId, int quantity);
        public record OrderDTO(Address Address, string CustomerName, string PhoneNumber, CustomerId? CustomerId = null);

        public class GetAllOrdersDTO
        {
            public OrderId id { get; set; }

            public GetAllOrdersDTO(OrderId id, string state, DateTime createdDate, string customerName, Address address, string phoneNumber, CustomerId customerId, decimal totalPrice)
            {
                this.id = id;
                State = state;
                this.createdDate = createdDate.ToString("dddd, MMMM d, yyyy - h:mm tt");
                this.address = address;
                this.phoneNumber = phoneNumber;
                CustomerId = customerId;
                this.totalPrice = totalPrice;
            }
            [JsonConverter(typeof(JsonStringEnumConverter))]
            public string State { get; set; }
            public string createdDate { get; set; }
            public string CustomerName { get; set; }
            public Address address { get; set; }
            public string phoneNumber { get; set; }
            public CustomerId CustomerId { get; set; }
            public decimal totalPrice { get; set; }
        }
        public record AddOrderDTO(List<OrderItemDTO>  OrderItemDTOs, Address Address, string CustomerName, string PhoneNumber, CustomerId CustomerId = null);
        public record AddressDTO( );

        public static OrderItemDTO OrderItem(ProductId productId, int quantity)
        {
            return new OrderItemDTO(productId, quantity);
        }

        public static OrderDTO Order(Address Address, string CustomerName, string PhoneNumber, CustomerId? CustomerId)
        {
            return new OrderDTO(Address, CustomerName, PhoneNumber, CustomerId);
        }

    
    }
    
    
}
