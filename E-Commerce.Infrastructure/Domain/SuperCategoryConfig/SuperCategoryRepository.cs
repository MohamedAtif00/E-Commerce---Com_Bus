using E_Commerce.Domain.Model.SuperCategoryAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.SuperCategoryConfig
{
    public class SuperCategoryRepository : GenericRepository<SuperCategory, SuperCategoryId>, ISuperCategoryRepository
    {
        public SuperCategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
