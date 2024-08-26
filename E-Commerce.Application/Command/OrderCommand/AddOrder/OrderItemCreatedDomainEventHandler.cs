using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.OrderAggre.Events;
using E_Commerce.Domain.Model.ProductAggre;
using MediatR;
using Microsoft.Extensions.Logging;


namespace E_Commerce.Application.Command.OrderCommand.AddOrder
{
    public class OrderItemCreatedDomainEventHandler : INotificationHandler<OrderItemCreatedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderItemCreatedDomainEventHandler> _logger;

        public OrderItemCreatedDomainEventHandler( ILogger<OrderItemCreatedDomainEventHandler> logger, IUnitOfWork unitOfWork)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrderItemCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(notification.ProductId);
                if (product == null)
                {
                    throw new Exception("Product is not exist") ; // Or handle the case where product is not found
                }

                product.DecreaseInventory(notification.quantity);

                //await _unitOfWork.ProductRepository.save(); // Ensure changes are saved

                _logger.LogInformation($"Inventory decreased for product {product._name}. Quantity: {notification.quantity}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling OrderItemCreatedDomainEvent.");
                // Rethrow or handle the exception as appropriate for your application
                //await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
