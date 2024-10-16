using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_Commerce.Application.Command.OrderCommand.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetById(command.OrderId,true);

                if (order == null)
                {
                    return Result.NotFound($"Order with ID {command.OrderId} not found.");
                }

                // Update order fields if the command provides values
                if (command.State.HasValue)
                {
                    order.State = command.State.Value;
                }

                if (!string.IsNullOrWhiteSpace(command.TrackingNumber))
                {
                    order.AddTrackingNumber(command.TrackingNumber);
                }

                if (command.Address != null)
                {
                    order.Address = command.Address;
                }

                // Save the changes to the database
                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("Error No data saved");

                return Result.Success();
            }
            catch (Exception ex)
            {
                // Log error (if applicable) and return a failure result
                return Result.Error("An error occurred while updating the order.");

            }
        }
    }
}
