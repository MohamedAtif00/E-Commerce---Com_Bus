using Ardalis.Result;
using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.CategoryQuery.GetAllCategoriesQuery
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<CategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories =  _unitOfWork.CategoryRepository.GetAllMod(x =>x.ChildCategories);


                List<CategoryDTO> categoryDTOs = new();
                foreach (var category in categories)
                {
                    var dto = new CategoryDTO() { Id= category.Id.value,Name=category._name};

                    categoryDTOs.Add(dto);
                }


                return Result.Success(categoryDTOs);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System error");
            }
        }
    }
}
