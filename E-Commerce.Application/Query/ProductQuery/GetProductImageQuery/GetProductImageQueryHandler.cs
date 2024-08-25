using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetProductImageQuery
{
    public class GetProductImageQueryHandler : IQueryHandler<GetProductImageQuery, Image>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductImageQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Image>> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
        {
            try
            {


                var image = await _unitOfWork.ImageRepository.GetById(request.id);


                if (image == null) return Result.NotFound("this image is not exist");

                return Result.Success(image);

            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
