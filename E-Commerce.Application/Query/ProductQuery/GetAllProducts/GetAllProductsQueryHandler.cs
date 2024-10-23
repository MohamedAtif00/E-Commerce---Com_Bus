using Ardalis.Result;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetAllProducts
{
    public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, PageList<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PageList<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productsQuery = await _unitOfWork.ProductRepository.GetPages();
                if (request.searchTerm != null)
                {
                    productsQuery = productsQuery.Where(p =>
                        p._name.Contains(request.searchTerm)
                    );
                }

                // Apply price range filter if provided
                if (request.startPrice != null)
                {
                    productsQuery = productsQuery.Where(p => p._price._total >= request.startPrice);
                }

                if (request.endPrice != null)
                {
                    productsQuery = productsQuery.Where(p => p._price._total <= request.endPrice);
                }

                if (request.CategoryIds != null && request.CategoryIds.Count() != 0)
                {

                    productsQuery = productsQuery.Where(p => request.CategoryIds.Contains(p.categoryId));
                }

                if (request.totalReviews != null)
                {
                    productsQuery = productsQuery.Where(p => p._totalReviews == request.totalReviews);
                }

                Expression<Func<Product, object>> keySelector = request.sortColumn?.ToLower() switch
                {
                    "name" => Product => Product._name,
                    "price" => Product => Product._price._total,
                    "stockquantity" => Product => Product._stockQuantity,
                    _ => Product => Product.Id
                };

                if (keySelector != null)
                {
                    if(request.asend)
                        productsQuery = productsQuery.OrderByDescending(keySelector);
                    else
                        productsQuery = productsQuery.OrderBy(keySelector);
                    
                }



                var pages = await PageList<Product>.CreateAsync(productsQuery,request.pageNumber,request.pageSize); 

                return Result.Success(pages);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
