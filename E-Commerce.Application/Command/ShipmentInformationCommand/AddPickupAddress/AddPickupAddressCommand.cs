using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ShipmentInformationCommand.AddPickupAddress
{
    public record AddPickupAddressCommand(AddPickupAddressDto address):ICommand;
    
    
}
