using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.CategryEarningChart
{
    public class GetCategoryEarningChartQueryHandler : IQueryHandler<GetCategoryEarningChartQuery, List<CategoryEarningChartDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryEarningChartQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<CategoryEarningChartDto>>> Handle(GetCategoryEarningChartQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Initialize the result list
                List<CategoryEarningChartDto> categoriesChart = new();

                // Fetch orders from the last 7 days
                var orders = await _unitOfWork.OrderRepository.GetLastDaysOrders(request.days);

                // Fetch all categories
                var categories = await _unitOfWork.CategoryRepository.GetAll();

                // Dictionary to store earnings per category
                var categoryEarnings = categories.ToDictionary(c => c.Id, c => 0m);

                // Calculate total earnings per category
                foreach (var order in orders)
                {
                    var orderItems = (await _unitOfWork.OrderRepository.GetOrderWithOrderItems(order))._orderItems;

                    foreach (var orderItem in orderItems)
                    {
                        // Assuming each orderItem has a CategoryId and a price
                        var product = await _unitOfWork.ProductRepository.GetById(orderItem._productId);
                        if (product != null)
                        {
                            var categoryId = product.categoryId;
                            var price = orderItem._total; // Assuming orderItem has a Price property

                            // Update earnings for the category
                            if (categoryEarnings.ContainsKey(categoryId))
                            {
                                categoryEarnings[categoryId] += price;
                            }
                        }
                    }
                }

                // Create DTOs for each category
                foreach (var category in categories)
                {
                    var totalEarnings = categoryEarnings.GetValueOrDefault(category.Id, 0m);
                    var dto = new CategoryEarningChartDto(category.Id, totalEarnings, category._name);
                    categoriesChart.Add(dto);
                }

                // Return the result wrapped in a Result object
                return Result.Success(categoriesChart);
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // Log.Error(ex, "Error occurred while handling GetCategoryEarningChartQuery");

                // Return a failure result with the exception message
                return Result.Error($"An error occurred: {ex.Message}");
            }
        }
    }
}
