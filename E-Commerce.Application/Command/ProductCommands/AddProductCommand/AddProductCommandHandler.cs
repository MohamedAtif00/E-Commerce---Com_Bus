using Ardalis.Result;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.AddProductCommand
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand,Product>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var price = Price.Create(request.product.price,request.product.discount,request.percentage);
                var product = Product.Create(request.product.categoryId,request.product.name,request.product.description,price,request.product.stockQuantity); 

                await _productRepository.Add(product);

                int saving = await _productRepository.save();
                if (saving == 0) return Result.Error("no change");
                return Result.Success(product);
            }
            catch
            (Exception ex)
            {
                return Result.Error();
            }
        }
    }
}
