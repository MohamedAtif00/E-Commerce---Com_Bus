﻿using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.CategryEarningChart
{
    public record GetCategoryEarningChartQuery(int days):IQuery<List<CategoryEarningChartDto>>;
    
    
}