using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetProductImage
{
    public class GetProductMasterImageQueryHandler : IQueryHandler<GetProductMasterImageQuery, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductMasterImageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(GetProductMasterImageQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId, false);

                var image = await _unitOfWork.ImageRepository.GetMasterImageByProductId(request.ProductId);

                if (image == null) return Result.Error("there is no image");

                return Result.Success(image.Path);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System error");
            }
        }
    }
}
