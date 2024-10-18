using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetSpecialProducts
{
    public class GetSpecialProductsQueryHandler : IQueryHandler<GetSpecialProductsQuery, List<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSpecialProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Product>>> Handle(GetSpecialProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetSpecialProducts(request.GroupId);

                return  Result.Success(products);
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
