﻿using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ShipmentInformationCommand.AddShipmentInformation
{
    public record AddShipmentInformationCommand(string email,string fullName,string token) : ICommand;
    
    
}