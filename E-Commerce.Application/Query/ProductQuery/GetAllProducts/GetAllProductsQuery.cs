﻿using E_Commerce.Application.Helper;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetAllProducts
{
    public record GetAllProductsQuery(int pageNumber,
                                      int pageSize,
                                      string? sortColumn,
                                      string? searchTerm,
                                      decimal? startPrice,
                                      decimal? endPrice,
                                      decimal? totalReviews,
                                      List<CategoryId>? CategoryIds,
                                      bool asend = false
                                      ) :IQuery<PageList<Product>>;
    
    
}
