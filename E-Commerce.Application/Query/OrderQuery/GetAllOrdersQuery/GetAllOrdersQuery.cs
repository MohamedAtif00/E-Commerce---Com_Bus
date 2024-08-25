using E_Commerce.Application.DTOs;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetAllOrdersQuery
{
    public record GetAllOrdersQuery(int pageNumber,int pageSize,string? sortColumn,string? searchTerm,bool des = false):IQuery<PageList<OrderDTOs.GetAllOrdersDTO>>;
    
    
}
