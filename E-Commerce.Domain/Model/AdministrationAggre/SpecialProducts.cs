using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class SpecialProducts : Entity<SpecialProductsId>
    {
        public SpecialProducts(SpecialProductsId id, ProductId productId) : base(id)
        {
            this.productId = productId;
        }

        public ProductId productId { get; set; }

        public static SpecialProducts Create(ProductId productId)
        {
            return new(SpecialProductsId.CreateUnique(),productId);
        }



    }
}
