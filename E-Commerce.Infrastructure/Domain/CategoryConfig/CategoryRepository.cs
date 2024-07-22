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
}


