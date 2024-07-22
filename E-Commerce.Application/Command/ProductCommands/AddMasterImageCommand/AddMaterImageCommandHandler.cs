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

namespace E_Commerce.Application.Command.ProductCommands.AddMasterImageCommand
{
    public class AddMaterImageCommandHandler : ICommandHandler<AddMasterImageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMaterImageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddMasterImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Save the image file to the server
                var savedImagePath = await ImageHelper.SaveImageAsync(request.file,request.rootPath, request.fileName);
                if (string.IsNullOrEmpty(savedImagePath))
                {
                    return Result.Error("Failed to save the image.");
                }

                // Create the image domain entity
                var image = Image.Create(savedImagePath.Split('/').Last(), request.ProductId, savedImagePath, true);

                // Add the image to the repository
                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId,true);


                product.AddMasterImage(image);

                await _unitOfWork.ProductRepository.Update(product);
                // Commit the changes
                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return a failed result
                return Result.Error($"An error occurred while adding the master image: {ex.Message}");
            }
        }
    }
}
