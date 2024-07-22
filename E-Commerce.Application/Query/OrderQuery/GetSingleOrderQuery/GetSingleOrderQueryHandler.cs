using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetSingleOrderQuery
{
    public class GetSingleOrderQueryHandler : IQueryHandler<GetSingleOrderQuery, Order>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Order>> Handle(GetSingleOrderQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetById(request.OrderId);

                if (order == null) return Result.NotFound("this order is not exist");

                return Result.Success(order);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
