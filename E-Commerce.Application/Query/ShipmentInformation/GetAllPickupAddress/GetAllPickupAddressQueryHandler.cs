using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ShipmentInformation.GetAllPickupAddress
{
    public class GetAllPickupAddressQueryHandler : IQueryHandler<GetAllPickupAddressQuery, List<PickupAddress>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPickupAddressQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PickupAddress>>> Handle(GetAllPickupAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var info = await _unitOfWork.ShipmentInformationRepository.GetInfo();
                if (info.pickupAddresses == null) return Result.Error("There is no pickup address");
                var addresses = info.pickupAddresses.ToList();

                if (addresses == null) return Result.Error("there is no address");

                return Result.Success(addresses);

            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
