using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.AddProductImagesCommand
{
    public record AddProductImagesCommand(ProductId ProductId,List<IFormFile> files,string rootPath,string folderName):ICommand;
    
    
}
