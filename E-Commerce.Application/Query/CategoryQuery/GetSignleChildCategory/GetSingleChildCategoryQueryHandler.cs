using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.CategoryQuery.GetSignleChildCategory
{
    public class GetSingleChildCategoryQueryHandler : IQueryHandler<GetSingleChildCategoryQuery, ChildCategory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleChildCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ChildCategory>> Handle(GetSingleChildCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var childcategory = await _unitOfWork.ChildCategoryRepository.GetById(request.id);

                if (childcategory == null) return Result.Error("this category is not exist");

                return Result.Success(childcategory);

            }
            catch (Exception ex)
            {
                return Result.Error("System Error");    
            }
        }
    }
}
