﻿using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.UpdateCarouselCommand
{
    public record UpdateCarouselCommand(GroupId GroupId,string name):ICommand;
    
    
}
