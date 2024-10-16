using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.AddCoupon
{
    public class AddCouponCommandHandler : ICommandHandler<AddCouponCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCouponCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddCouponCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var coupon = Coupon.Create(request.code,request.discount,request.expirationDate,request.isActive,request.usageLimit);

                await _unitOfWork.CouponRepository.Add(coupon);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error"); 
            }
        }
    }
}
