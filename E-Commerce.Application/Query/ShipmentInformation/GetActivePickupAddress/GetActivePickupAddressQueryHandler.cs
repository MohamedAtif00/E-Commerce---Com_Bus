using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ShipmentInformation.GetActivePickupAddress
{
    public class GetActivePickupAddressQueryHandler : IQueryHandler<GetActivePickupAddressQuery, PickupAddress>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActivePickupAddressQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PickupAddress>> Handle(GetActivePickupAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var info = await _unitOfWork.ShipmentInformationRepository.GetInfo();
                var address = info.pickupAddresses.FirstOrDefault();

                if (address == null) return Result<PickupAddress>.NotFound();

                return Result.Success(address);
            }
            catch (Exception ex)
            {
                return Result<PickupAddress>.CriticalError("System Error");
            }
        }
    }
}
