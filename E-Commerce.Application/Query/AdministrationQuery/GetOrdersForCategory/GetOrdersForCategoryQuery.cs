﻿using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetOrdersForCategory
{
    public record GetOrdersForCategoryQuery(CategoryId  CategoryId):IQuery<List<GetOrdersForCategoryDto>>;
    
    
}