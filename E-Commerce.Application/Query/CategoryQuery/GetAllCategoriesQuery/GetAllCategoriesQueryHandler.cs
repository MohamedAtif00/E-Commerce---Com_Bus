using Ardalis.Result;
using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;


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
                var categories = await _unitOfWork.CategoryRepository.GetAll();


                List<CategoryDTO> categoryDTOs = categories.Select(x =>new CategoryDTO {Id=x.Id.value,Name=x._name}).ToList();
                //foreach (var category in categories)
                //{
                //    var dto = new CategoryDTO() { Id= category.Id.value,Name=category._name};

                //    categoryDTOs.Add(dto);
                //}

            

                return Result.Success(categoryDTOs );
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System error");
            }
        }
    }
}
