using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.productConfig
{
    public class ImageRepository : GenericRepository<Image, ImageId>, IImageRepository
    {
        public ImageRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Image> GetMasterImageByProductId(ProductId productId)
        {
            //var product = await _context.products.FirstOrDefaultAsync(x => x.Id == productId);
            return await _context.images.Where(x => x.ProductId == productId && x.IsMaster && !x.IsRemoved).SingleOrDefaultAsync();
        }

        public async Task<List<Image>> GetImage(ProductId productId)
        {
            return _context.images.Where(x => x.ProductId == productId && !x.IsRemoved && !x.IsMaster).ToList();
        }

        public async Task AddRange(List<Image> images)
        {
            await _context.AddRangeAsync(images);        
        }

        
    }
}
