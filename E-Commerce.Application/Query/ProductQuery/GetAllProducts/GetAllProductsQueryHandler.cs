using Ardalis.Result;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
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
