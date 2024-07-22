using E_Commerce.Application.DTOs;
using E_Commerce.SharedKernal.Application;

namespace E_Commerce.Application.Command.OrderCommand.AddOrder
{
    public record AddOrderCommand(OrderDTOs.AddOrderDTO order) : ICommand;
    //{
    //    public AddOrderCommand(OrderDTOs.AddOrderDTO order)
    //    {
    //        this.order = order;
    //    }

    //    public OrderDTOs.AddOrderDTO order { get; set; }

    //}

    
    
    
}
