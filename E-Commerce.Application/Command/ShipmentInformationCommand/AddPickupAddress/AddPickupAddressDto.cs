using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ShipmentInformationCommand.AddPickupAddress
{
    public record AddPickupAddressDto(string state, string city, string stateId, string cityId, string firstLine,
                                      string? secondLine, int buildingNumber, int floor, string apartment);

}
