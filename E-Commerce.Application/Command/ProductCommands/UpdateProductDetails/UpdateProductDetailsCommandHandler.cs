using Ardalis.Result;
using E_Commerce.Application.Helper;
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
    public class UpdateProductDetailsCommandHandler : ICommandHandler<UpdateProductDetailsCommand,Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductDetailsCommandHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Product>> Handle(UpdateProductDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Fetch the product by ID, including its images
                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId,true);
                if (product == null)
                {
                    return Result.Error("Product not found");
                }

                // Update product details
                
                var price = Price.Create(request.price, request.discount, request.hasPercentage);
                product.UpdateDetails(request.name,
                                      request.nameArab,
                                      request.description,
                                      request.descriptionArab,
                                      request.stsockQuantity, // Corrected from 'sstockQuantity' to 'stockQuantity'
                                      price,
                                      request.CategoryId);

                //Remove all images from the product
                var masterImage = await _unitOfWork.ImageRepository.GetMasterImageByProductId(request.ProductId);
                if (masterImage != null)
                { 
                    await _unitOfWork.ImageRepository.Delete(masterImage);
                    var deletemasterImage =  ImageHelper.DeleteImage(masterImage.Path,request.rootPath);
                }
                var images = await _unitOfWork.ImageRepository.GetImage(request.ProductId);
                foreach (var image in images)
                {
                    await _unitOfWork.ImageRepository.Delete(image);
                    ImageHelper.DeleteImage(image.Path,request.rootPath);
                }
                // Update the product in the repository
                await _unitOfWork.ProductRepository.Update(product);

                // Save changes
                var savingResult = await _unitOfWork.save(); // Ensure 'Save' method is named correctly

                if (savingResult == 0)
                {
                    return Result.Error("No changes were made");
                }

                return Result.Success(product);
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return Result.Error($"An error occurred while updating the product: {ex.Message}");
            }
        }


    }
}
