using Ardalis.Result;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.DeleteProductCommand
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(request.id);

                if (product == null) return Result.Error("this product is not exist");


                // Delete Product images
                foreach (var image in await _unitOfWork.ImageRepository.GetImage(product.Id))
                {
                     ImageHelper.DeleteImage(image.Path,request.rootPath);
                }
                // Delete master image
                var masterImage = await _unitOfWork.ImageRepository.GetMasterImageByProductId(product.Id);
                ImageHelper.DeleteImage(masterImage.Path,request.rootPath);
;

                await _unitOfWork.ProductRepository.Delete(product);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No change");

                return Result.Success();
            }
            catch (Exception ex) {
                return Result.Error("System Error");
            }
        }
    }
}
