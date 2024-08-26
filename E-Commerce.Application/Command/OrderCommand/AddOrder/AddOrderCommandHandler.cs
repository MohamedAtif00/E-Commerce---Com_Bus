using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.AddOrder
{
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork ;

        public AddOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Create the order from the request
                var order = Order.Create(request.order.CustomerId, request.order.Address, request.order.CustomerName, request.order.PhoneNumber,0);

                List<OrderItem> orderItems = new List<OrderItem>();

                // Calculate Total Price
                foreach (var orderItem in request.order.OrderItemDTOs)
                {
                    var product = await _unitOfWork.ProductRepository.GetById(orderItem.productId);
                    if (product == null)
                    {
                        return Result.Error($"Product with ID {orderItem.productId} not found.");
                    }

                    var total = (decimal)product._price._total * orderItem.quantity;

                    var newOrderItem = OrderItem.Create(orderItem.productId, orderItem.quantity, total, order.Id);
                    orderItems.Add(newOrderItem);
                }

                var totalOrderPrice = orderItems.Sum(x => x._total);

                // Update the total price of the order
                order.TotalPrice = totalOrderPrice;

                // Add the order items to the order
                order.AddRangeOrderItem(orderItems);

                // Add the order to the repository
                await _unitOfWork.OrderRepository.Add(order);

                // Save changes to the repository
                int saving = await _unitOfWork.save();

                return Result.Success();
            }
            catch (Exception ex)
            {
                // Log the exception (if you have a logging mechanism)
                return Result.Error("System Error: " + ex.Message);
            }
        }
    }
}
