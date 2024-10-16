using AutoMapper;
using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Model.OrderAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Commerce.Application.DTOs.OrderDTOs;

namespace E_Commerce.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<OrderDTOs.AddOrderDTO, Order>()
            //.ConstructUsing(dto => Order.Create(dto.CustomerId, dto.Address, dto.CustomerName, dto.PhoneNumber))
            //.ForMember(dest => dest._customerId, opt => opt.MapFrom(src => src.CustomerId))
            //.ForMember(dest => dest._orderItems, opt => opt.Ignore())  // _orderItems are handled in ConstructUsing
            //.ReverseMap()
            //.ForMember(dest => dest.OrderItemDTOs, opt => opt.MapFrom(src => src._orderItems));

            // Mapping OrderDTOs.OrderItemDTO to OrderItem
            //CreateMap<OrderDTOs.OrderItemDTO, OrderItem>()
            //    .ConstructUsing(dto => OrderItem.Create(dto.productId, dto.quantity, dto.total,null))
            //    .ReverseMap()
            //    .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src._productId))
            //    .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src._quantity))
            //    .ForMember(dest => dest.total, opt => opt.MapFrom(src => src._total));

            CreateMap<Order, GetAllOrdersDTO>()
            .ConstructUsing(src => new GetAllOrdersDTO(
                src.Id,
                src.State.ToString(),
                src.CreatedDate,
                src.CustomerName,
                src.Address,
                src.PhoneNumber,
                src._customerId,
                src.TotalPrice,
                src.TrackingNumber
            )).ReverseMap();



        }
    }
    
}
