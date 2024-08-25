using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetSingleOrderQuery
{
    public class GetSingleOrderQueryHandler : IQueryHandler<GetSingleOrderQuery, GetSingleOrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetSingleOrderDto>> Handle(GetSingleOrderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetById(request.OrderId);

                if (order == null) return Result.NotFound("this order is not exist");

                List<OrderItemDto> products = new();

                foreach (var orderItem in order._orderItems)
                {
                    var product = await _unitOfWork.ProductRepository.GetById(orderItem._productId);

                    OrderItemDto Dto = new(product.Id,product._name,product._stockQuantity,product._price._total,orderItem._total);

                    products.Add(Dto);
                }

                GetSingleOrderDto OrderDto = new(order.Id,order.CustomerName,order.PhoneNumber,order.CreatedDate,order.Address,products,order.TotalPrice);


                return Result.Success(OrderDto);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
