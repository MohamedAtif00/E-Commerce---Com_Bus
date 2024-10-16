using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.BasketAggre;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext _context { get; }

        public UnitOfWork(ApplicationContext context, IProductRepository productRepository, IOrderRepository orderRepository, ICategoryRepository categoryRepository, ISpecificationRepository specificationRepository, IImageRepository imageRepository, IAdministrationRepository administrationRepository, ISpecialProductsRepository specialProductsRepository, IContactRepository contactRepository, IShipmentInformationRepository shipmentInformationRepository, IChildCategoryRepository childCategoryRepository, ICouponRepository couponRepository)
        {
            _context = context;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            CategoryRepository = categoryRepository;
            SpecificationRepository = specificationRepository;
            ImageRepository = imageRepository;
            AdministrationRepository = administrationRepository;
            SpecialProductsRepository = specialProductsRepository;
            this.contactRepository = contactRepository;
            ShipmentInformationRepository = shipmentInformationRepository;
            ChildCategoryRepository = childCategoryRepository;
            CouponRepository = couponRepository;
        }

        public IProductRepository ProductRepository { get; set; }
        public IImageRepository ImageRepository { get; set; }   

        public IOrderRepository OrderRepository { get; set; }
        public ICouponRepository CouponRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IChildCategoryRepository ChildCategoryRepository { get; set; }
        public ISpecificationRepository SpecificationRepository { get; set; }
        public IAdministrationRepository AdministrationRepository { get; set; }
        public ISpecialProductsRepository SpecialProductsRepository { get; set; }
        public IContactRepository contactRepository { get; set; }
        public IShipmentInformationRepository ShipmentInformationRepository { get; set; }


        public async Task<int> save()
        {
           return await  _context.SaveChangesAsync();
        }


        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (disposing)
        //        {
        //            // TODO: dispose managed state (managed objects)
        //            _context.Dispose();
        //        }

        //        // TODO: free unmanaged resources (unmanaged objects) and override finalizer
        //        // TODO: set large fields to null
        //    }
        //}

        public async Task RollbackAsync()
        {
            await _context.Database.CurrentTransaction.RollbackAsync();
        }


        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        //public void Dispose()
        //{
        //    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //    Dispose(disposing: true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
