using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.ProductAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class BasketDTO
    {
        public record CreateBasketDTO(CustomerId CustomerId,decimal price);

        public record BasketItemDTO(ProductId ProductId , decimal price_unit ,decimal price_total,int quantity);
    }
}
