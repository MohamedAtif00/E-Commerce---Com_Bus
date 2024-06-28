using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductOptionAggre
{
    public class ProductOption : AggregateRoot<ProductOptionId>
    {
        public ProductOption(ProductOptionId id, ProductId productId, OptionsId optionsId) : base(id)
        {
            _productId = productId;
            _optionsId = optionsId;
        }

        public ProductId _productId { get;private set; }
        public OptionsId _optionsId { get; private set; }


        public static ProductOption Create(ProductId productId,OptionsId optionsId)
        {
            return new(ProductOptionId.CreateUnique(),productId,optionsId);
        }

        public void Update(ProductId productId, OptionsId optionsId)
        {
            _productId = productId;
            _optionsId = optionsId;
        }
    }
}
