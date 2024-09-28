using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ShipmentInformationCommand.AddShipmentToken
{
    public class AddShipmentTokenCommandHandler : ICommandHandler<AddShipmentTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddShipmentTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddShipmentTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var shipments = await _unitOfWork.ShipmentInformationRepository.GetAll();

                if (shipments.Count == 0) return Result.Error("there is no information");

                var shipmetn = shipments.FirstOrDefault();

                shipmetn.SetToken(request.token);

                await _unitOfWork.ShipmentInformationRepository.Update(shipmetn);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("there is no change ");

                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Error(ex.ToString());
            }
        }
    }
}
