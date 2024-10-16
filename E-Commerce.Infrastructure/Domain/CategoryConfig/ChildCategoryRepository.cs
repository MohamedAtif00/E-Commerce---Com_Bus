using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.CategoryConfig
{
    public class ChildCategoryRepository : GenericRepository<ChildCategory, ChildCategoryId>,IChildCategoryRepository
    {
        public ChildCategoryRepository(ApplicationContext context) : base(context)
        {
        }


    }
}
