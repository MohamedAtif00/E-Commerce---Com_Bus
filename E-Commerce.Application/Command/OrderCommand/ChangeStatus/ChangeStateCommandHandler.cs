using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.ChangeStatus
{
    public class ChangeStateCommandHandler : ICommandHandler<ChangeStateCommand>
    {
        public readonly IUnitOfWork _unitOfWork;

        public ChangeStateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeStateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetById(request.id);

                if (order == null) return Result.NotFound();

                if (!Enum.IsDefined(typeof(OrderState),request.state)) return Result.Error("not defined state value");

                order.State = request.state;

                await _unitOfWork.OrderRepository.Update(order);

                int saving = await _unitOfWork.save();
                if(saving == 0) return Result.Error("No Changes");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.ToString());
            }
        }
    }
}
