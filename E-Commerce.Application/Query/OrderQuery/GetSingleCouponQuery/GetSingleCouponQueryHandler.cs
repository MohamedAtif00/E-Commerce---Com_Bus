using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetSingleCouponQuery
{
    public class GetSingleCouponQueryHandler : IQueryHandler<GetSingleCouponQuery, Coupon>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleCouponQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Coupon>> Handle(GetSingleCouponQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var coupon = await _unitOfWork.CouponRepository.GetCouponByName(request.code);
                string message;

                if (coupon == null) return Result.NotFound("This Coupon is not exist.");
                if (coupon.UsageCount >= coupon.UsageLimit)
                { 
                    message = "This coupon reached its limit";

                    return Result.Success(coupon,message);
                }

                return Result.Success(coupon);

            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
