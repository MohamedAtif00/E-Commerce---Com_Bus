﻿using Ardalis.Result;
using AutoMapper;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetAllOrdersQuery
{
    public class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, PageList<OrderDTOs.GetAllOrdersDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PageList<OrderDTOs.GetAllOrdersDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the paginated orders
                var ordersQuery = await _unitOfWork.OrderRepository.GetPages();

                // Create the paginated result
                var paginatedOrders = await PageList<Order>.CreateAsync(ordersQuery, request.pageNumber, request.pageSize);

                // Map the paginated orders to OrderDTOs.GetAllOrdersDTO
                var orderDTOs = paginatedOrders.items.Select(order => _mapper.Map<OrderDTOs.GetAllOrdersDTO>(order)).ToList();

                // Create a paginated DTO result
                var paginatedOrderDTOs = new PageList<OrderDTOs.GetAllOrdersDTO>(
                    orderDTOs,
                    paginatedOrders.page,
                    paginatedOrders.pageSize,
                    paginatedOrders.totalCount
                );

                return Result.Success(paginatedOrderDTOs);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("Critical Error: " + ex.Message);
            }
        }
    }
}