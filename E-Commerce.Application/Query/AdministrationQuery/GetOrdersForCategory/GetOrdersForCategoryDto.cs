using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetOrdersForCategory
{
    public class GetOrdersForCategoryDto
    {
        public GetOrdersForCategoryDto(ProductId ProductId,
                                       string itemName,
                                       int quantity,
                                       decimal priceForUnit,
                                       decimal totalPrice)
        {
            this.ProductId = ProductId;
            ItemName = itemName;
            Quantity = quantity;
            PriceForUnit = priceForUnit;
            TotalPrice = totalPrice;
        }

        public ProductId ProductId { get; }
        public string ItemName { get; }
        public int Quantity { get; set; }
        public decimal PriceForUnit { get; }
        public decimal TotalPrice { get; set; }
    }
    
    
}
