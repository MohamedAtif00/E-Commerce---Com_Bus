using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ShipmentInformationCommand.AddPickupAddress
{
    public class AddPickupAddressCommandHandler : ICommandHandler<AddPickupAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPickupAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddPickupAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var info = await _unitOfWork.ShipmentInformationRepository.GetInfo();
                if (info == null)
                {
                    return Result.NotFound();
                }

                var address =  PickupAddress.Create(request.address.state,
                                                         request.address.city,
                                                         request.address.stateId,
                                                         request.address.cityId,
                                                         request.address.firstLine,
                                                         request.address.secondLine,
                                                         request.address.buildingNumber,
                                                         request.address.floor,
                                                         request.address.apartment);

                info.AddPickupAddress(address);

                await _unitOfWork.ShipmentInformationRepository.Update(info);

                int saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("No change");

                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
