using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.DailyEarningChart
{
    public class DailyEarningChartQueryHandler : IQueryHandler<DailyEarningChartQuery, List<DailyEarningSummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DailyEarningChartQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<DailyEarningSummaryDto>>> Handle(DailyEarningChartQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch orders for the last `days` days
                var orders = await _unitOfWork.OrderRepository.GetLastDaysOrders(7);

                var dailyEarningSummaryDtos = new List<DailyEarningSummaryDto>();

                // Calculate daily earnings
                for (int i = 0; i < 7; i++)
                {
                    // Calculate the date for the current day in the loop
                    DateTime targetDate = DateTime.UtcNow.AddDays(-i).Date;

                    // Filter orders for the current date
                    var dailyOrders = orders.Where(x => x.CreatedDate.Date == targetDate);

                    // Calculate total earnings for the current date
                    decimal total = dailyOrders.Sum(x => x.TotalPrice);

                    // Add to DTO list
                    dailyEarningSummaryDtos.Add(new DailyEarningSummaryDto(
                        targetDate.ToString("dddd"), // Format date as needed
                        total
                    ));
                }

                return Result.Success(dailyEarningSummaryDtos);

            }
            catch (Exception ex) 
            {
                return Result.CriticalError("System error");
            }
        }
    }
}
