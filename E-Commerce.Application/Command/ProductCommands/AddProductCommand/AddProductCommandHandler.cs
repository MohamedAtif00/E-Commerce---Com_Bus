using Ardalis.Result;
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
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var price = Price.Create(request.price,request.discount);
                var product = Product.Create(request.name,request.description,price,request.stockQuantity);
                await _productRepository.Add(product);

                int saving = await _productRepository.save();
                if (saving == 0) return Result.Error("no change");
                return Result.Success();
            }
            catch
            (Exception ex)
            {
                return Result.Error();
            }
        }
    }
}
