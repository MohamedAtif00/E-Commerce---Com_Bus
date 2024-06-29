using E_Commerce.Domain.Model.ProductOptionAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ProductOptionConfig
{
    public class ProductOptionRepository : GenericRepository<ProductOption, ProductOptionId>, IProductOptionRepository
    {
        public ProductOptionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
