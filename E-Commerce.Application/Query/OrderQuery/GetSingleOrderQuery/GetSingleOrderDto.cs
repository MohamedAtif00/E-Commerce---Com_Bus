using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetSingleOrderQuery
{
    public record GetSingleOrderDto(OrderId OrderId,string customerName,string phoneNumber,DateTime createdDate,Address Address,List<OrderItemDto> Products,decimal total,string state,string? trackingNumber);
    
    public record OrderItemDto(ProductId ProductId,string productName,int quantity,decimal PriceForUnit,decimal total);
   
}
