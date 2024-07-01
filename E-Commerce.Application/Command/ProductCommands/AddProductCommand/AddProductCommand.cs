using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;


namespace E_Commerce.Application.Command.ProductCommands.AddProductCommand
{
    public record AddProductCommand(string name,
                                    string description,
                                    int discount,
                                    decimal price,
                                    int stockQuantity):ICommand;
    
    
}
