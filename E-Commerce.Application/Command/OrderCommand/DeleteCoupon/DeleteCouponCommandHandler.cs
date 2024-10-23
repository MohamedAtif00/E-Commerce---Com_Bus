using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.DeleteCoupon
{
    public class DeleteCouponCommandHandler : ICommandHandler<DeleteCouponCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCouponCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var coupon = await _unitOfWork.CouponRepository.GetById(request.id,true);

                await _unitOfWork.CouponRepository.Delete(coupon);
                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No chnage");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
