using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public interface IProductRepository : IGenericRepository<Product, ProductId>
    {
        Task<List<Review>> GetAllReviews();
        Task<IQueryable<Product>> GetPages();
        Task<List<Product>> GetSpecialProducts(GroupId groupId);
    }
}
