using E_Commerce.Domain.Model.CategoryAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.CategryEarningChart
{
    public record CategoriesEarningChartsDto();
    public record CategoryEarningChartDto(CategoryId CategoryId,decimal total,string categoryName);
    
}
