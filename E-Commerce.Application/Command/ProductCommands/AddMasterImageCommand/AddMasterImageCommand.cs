using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using Microsoft.AspNetCore.Http;


namespace E_Commerce.Application.Command.ProductCommands.AddMasterImageCommand
{
    public record AddMasterImageCommand(ProductId ProductId,IFormFile file,string rootPath,string fileName):ICommand;
    
    
}
