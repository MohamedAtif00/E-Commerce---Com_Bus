using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.product
{
    public class ProductRepository : GenericRepository<Product, ProductId>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
