using Ardalis.Result;
using E_Commerce.Domain.Common;
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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductDetailsCommandHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateProductDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId);
                product.UpdateDetails(request.name, request.description, request.stsockQuantity);

                int saving = await _unitOfWork.save();

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
