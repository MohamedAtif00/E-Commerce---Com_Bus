using Ardalis.Result;
using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.CategoryQuery.GetSingleCategoryQuery
{
    public class GetSingleCategoryQueryHandler : IQueryHandler<GetSingleCategoryQuery, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CategoryDTO>> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch the category by id, including its child categories
                var category = await _unitOfWork.CategoryRepository.GetByIdIncludeChildren(request.id);

                if (category == null)
                    return Result.NotFound("This category does not exist");

                // Map the category to a DTO
                var categoryDTO = MapCategoryToDTO(category);

                return Result.Success(categoryDTO);
            }
            catch (Exception ex)
            {
                // Log or handle exception if necessary
                return Result.CriticalError("System Error");
            }
        }

        private CategoryDTO MapCategoryToDTO(Category category)
        {
            // Create DTO for the category
            var categoryDTO = new CategoryDTO
            {
                Id = category.Id.value,
                Name = category._name,
                ChildsCategories = new List<CategoryDTO>() // Initialize child categories list
            };

            // Recursively map child categories if they exist
            if (category.ChildCategories != null && category.ChildCategories.Any())
            {
                categoryDTO.ChildsCategories = category.ChildCategories.Select(MapChildCategoryToDTO).ToList();
            }

            return categoryDTO;
        }


        private CategoryDTO MapChildCategoryToDTO(ChildCategory childCategory)
        {
            // Create DTO for the child category
            var childCategoryDTO = new CategoryDTO
            {
                Id = childCategory.Id.value,
                Name = childCategory._name,
                ChildsCategories = new List<CategoryDTO>() // Initialize child categories list
            };

            // Recursively map further nested child categories if they exist
            if (childCategory.ChildCategories != null && childCategory.ChildCategories.Any())
            {
                childCategoryDTO.ChildsCategories = childCategory.ChildCategories.Select(MapChildCategoryToDTO).ToList();
            }

            return childCategoryDTO;
        }
    }
}
