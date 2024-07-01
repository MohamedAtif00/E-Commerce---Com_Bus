using Ardalis.Result;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.UpdateProductDetails
{
    public class UpdateProductDetailsCommandHandler : ICommandHandler<UpdateProductDetailsCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductDetailsCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateProductDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetById(request.ProductId);
                product.UpdateDetails(request.name, request.description, request.stsockQuantity);

                int saving = await _productRepository.save();

                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return  Result.Error(ex.Message);   
            }
        }
    }
}
