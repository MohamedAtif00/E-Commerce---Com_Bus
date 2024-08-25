using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetOrdersForCategory
{
    public class GetOrdersForCategoryQueryHandler : IQueryHandler<GetOrdersForCategoryQuery, List<GetOrdersForCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersForCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetOrdersForCategoryDto>>> Handle(GetOrdersForCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _unitOfWork.AdministrationRepository.GetOrdersProductForCategory(request.CategoryId);

                List<GetOrdersForCategoryDto> orders = new();

                foreach (var product in products)
                {
                    var existingOrder = orders.FirstOrDefault(x => x.ProductId == product.Id);

                    if (existingOrder != null)
                    {
                        // Update the existing entry
                        existingOrder.TotalPrice += existingOrder.PriceForUnit;
                        existingOrder.Quantity++;
                    }
                    else
                    {
                        // Add a new entry
                        var orderDto = new GetOrdersForCategoryDto(product.Id, product._name,1, product._price._total, product._price._total);

                        orders.Add(orderDto);
                    }
                }

                return Result<List<GetOrdersForCategoryDto>>.Success(orders);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return Result<List<GetOrdersForCategoryDto>>.CriticalError($"An error occurred: {ex.Message}");
            }
        }

    }
}
