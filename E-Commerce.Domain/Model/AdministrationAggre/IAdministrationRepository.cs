using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public interface IAdministrationRepository : IGenericRepository<Administration, AdministrationId>
    {
        Task<Administration> GetAdministration();
        Task<List<Product>> GetOrdersProductForCategory(CategoryId categoryId);
    }
}
