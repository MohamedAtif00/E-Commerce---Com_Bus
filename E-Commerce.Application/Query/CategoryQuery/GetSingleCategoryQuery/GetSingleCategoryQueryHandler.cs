using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.CategoryQuery.GetSingleCategoryQuery
{
    public class GetSingleCategoryQueryHandler : IQueryHandler<GetSingleCategoryQuery, Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Category>> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetById(request.id);

                if (category == null) return Result.NotFound("this category is not exist");

                return Result.Success(category);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
