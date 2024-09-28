using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ShipmentInformationCommand.AddShipmentInformation
{
    public class AddShipmentInformationCommandHandler : ICommandHandler<AddShipmentInformationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddShipmentInformationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddShipmentInformationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var information = ShipmentInformation.Create(request.email,request.fullName);

                information.SetToken(request.token);

                await _unitOfWork.ShipmentInformationRepository.Add(information);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No change");
                
                return Result.Success();    
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
