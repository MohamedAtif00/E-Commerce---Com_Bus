using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CategoryAggre
{
    public interface ICategoryRepository : IGenericRepository<Category, CategoryId>
    {
        List<Category> GetAllMod(params Expression<Func<Category, object>>[] including);
    }
}
