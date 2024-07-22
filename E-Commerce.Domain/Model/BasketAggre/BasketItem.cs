using E_Commerce.Domain.Model.ProductAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.BasketAggre
{
    public class BasketItem
    {
        public ProductId ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price_unit { get; set; }
        public decimal Price_total { get; set; }
    }
}
