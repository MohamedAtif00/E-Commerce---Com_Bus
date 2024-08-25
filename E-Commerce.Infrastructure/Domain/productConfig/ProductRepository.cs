using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using E_Commerce.SharedKernal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.productConfig
{
    public class ProductRepository : GenericRepository<Product, ProductId>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<List<Product>> GetAll()
        {
            return await _context.products.Include(x =>x.images.Where(x =>x.IsMaster && !x.IsRemoved)).ToListAsync();
        }

        public async Task<IQueryable<Product>> GetPages()
        {
            return  _context.products.Include(x => x.images.Where(x => x.IsMaster));
        }

    }
}
