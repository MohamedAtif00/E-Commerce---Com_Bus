using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetSpecialProducts
{
    public class GetSpecialProductsQueryHandler : IQueryHandler<GetSpecialProductsQuery, List<GetSpecialProductsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSpecialProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetSpecialProductsDto>>> Handle(GetSpecialProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _unitOfWork.SpecialProductsRepository.GetAll();

                List<GetSpecialProductsDto> dto = new();

                foreach (var product in products)
                {
                    dto.Add(new GetSpecialProductsDto(product.productId));
                }

                return Result.Success(dto);
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
