using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IQueryHandler<GetSingleProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Product>> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(request.id);



                if (product == null) return Result.NotFound();

                var images = await _unitOfWork.ImageRepository.GetImage(request.id);

                product.AddImages(images);

                return Result.Success(product);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
