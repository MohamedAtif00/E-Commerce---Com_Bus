using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.BasketAggre;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.Domain.Model.SuperCategoryAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Common
{
    public interface IUnitOfWork 
    {
        IProductRepository ProductRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        ISuperCategoryRepository SuperCategoryRepository { get; set; }
        ISpecificationRepository SpecificationRepository { get; set; }
        IImageRepository ImageRepository { get; set; }
        IAdministrationRepository AdministrationRepository { get; set; }
        ISpecialProductsRepository SpecialProductsRepository { get; set; }
        IContactRepository contactRepository { get; set; }
        IShipmentInformationRepository ShipmentInformationRepository { get; set; }

        Task RollbackAsync();
        Task<int> save();
    }
}
