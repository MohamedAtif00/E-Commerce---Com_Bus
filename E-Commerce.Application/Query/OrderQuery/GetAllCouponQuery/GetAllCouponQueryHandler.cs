using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetAllCouponQuery
{
    public class GetAllCouponQueryHandler : IQueryHandler<GetAllCouponQuery, List<Coupon>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCouponQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Coupon>>> Handle(GetAllCouponQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var coupons = await _unitOfWork.CouponRepository.GetAll();

                return Result.Success(coupons);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Errors");
            }
        }
    }
}
