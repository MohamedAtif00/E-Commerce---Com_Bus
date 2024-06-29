using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Infrastructure.Data;


namespace E_Commerce.Infrastructure.Domain.CategoryConfig;

public class CategoryRepository : GenericRepository<E_Commerce.Domain.Model.CategoryAggre.Category, CategoryId>,ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }
}

