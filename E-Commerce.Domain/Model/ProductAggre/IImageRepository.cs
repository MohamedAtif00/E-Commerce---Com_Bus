using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public interface IImageRepository : IGenericRepository<Image, ImageId>
    {
        Task AddRange(List<Image> images);
        Task<List<Image>> GetImage(ProductId productId);
        Task<Image> GetMasterImageByProductId(ProductId productId);
    }
}
