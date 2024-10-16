using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Infrastructure.Data;
using E_Commerce.SharedKernal.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace E_Commerce.Infrastructure.Domain.CategoryConfig;

public class CategoryRepository : GenericRepository<Category, CategoryId>,ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }


    public  List<Category> GetAllMod(params Expression<Func<Category, object>>[] including)
    {

        var include = _context.Set<Category>().AsQueryable();
        including.ToList().ForEach(item =>
        {
            include = include.Include(item);
        });
        return include.ToList();
        
    }
    public async Task<List<Category>> GetAllIncludingChildren()
    {
        // Eager load all categories along with their child categories and nested child categories
        var categories = await _context.Set<Category>()
                                       .Include(c => c.ChildCategories) // Include immediate child categories
                                       .ThenInclude(cc => cc.ChildCategories) // Include nested child categories
                                       .ThenInclude(x => x.ChildCategories)
                                       .ToListAsync();

        return categories;
    }

    public async Task<Category> GetByIdIncludeChildren(CategoryId categoryId)
    {
        var category = await _context.categories.Where(x => x.Id == categoryId)
                                                .Include(c => c.ChildCategories)
                                                .ThenInclude(x => x.childCategory)
                                                .ThenInclude(x => x.childCategory)
                                                .SingleOrDefaultAsync();
        return category;
    }









}


