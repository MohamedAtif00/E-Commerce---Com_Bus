﻿using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.DeleteMasterImageCommand
{
    public record DeleteMasterImageCommand(ProductId ProductId,string webRootPath):ICommand;
    
    
}
