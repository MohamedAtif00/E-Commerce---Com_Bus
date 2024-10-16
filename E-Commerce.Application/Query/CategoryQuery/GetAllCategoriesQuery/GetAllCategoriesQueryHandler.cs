using Ardalis.Result;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Query.CategoryQuery.GetAllCategoriesQuery;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using Microsoft.Extensions.Logging;

public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GetAllCategoriesQueryHandler> _logger;

    public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllCategoriesQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<List<CategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Fetch all categories and their child categories in one query
            var categories = await _unitOfWork.CategoryRepository.GetAllIncludingChildren();

            // Map all categories to DTOs
            var categoryDTOs = categories.Select(MapCategoryToDTO).ToList();

            return Result.Success(categoryDTOs);
        }
        catch (Exception ex)
        {
            // Log the error for debugging purposes
            _logger.LogError(ex, "Error fetching categories");
            return Result.CriticalError("System error occurred");
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
