using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class ProductDTOs
    {
        public record CreateProductDTO(string name,
                                    string description,
                                    int discount,
                                    CategoryId categoryId,
                                    decimal price,
                                    bool? hasPercentage,
                                    int stockQuantity);

        public record UpdateProductDTO();
        
        public record CreateProductImageDTO(IFormFile file,ProductId ProductId);
    }
}
