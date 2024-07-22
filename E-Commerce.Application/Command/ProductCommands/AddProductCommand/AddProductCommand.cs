using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;


namespace E_Commerce.Application.Command.ProductCommands.AddProductCommand
{
    public record AddProductCommand(ProductDTOs.CreateProductDTO product) :ICommand<Product>;
    
    
}
