using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.UpdateOrder
{
    public class UpdateOrderCommand :ICommand
    {
        public OrderId OrderId { get; set; }
        public OrderState? State { get; set; }  // Nullable if the user doesn't want to update this field
        public string? TrackingNumber { get; set; }
        public Address? Address { get; set; }
    }
}
