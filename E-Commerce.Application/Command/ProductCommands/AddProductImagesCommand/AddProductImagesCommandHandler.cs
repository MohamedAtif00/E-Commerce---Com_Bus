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

namespace E_Commerce.Application.Command.ProductCommands.AddProductImagesCommand
{
    public class AddProductImagesCommandHandler : ICommandHandler<AddProductImagesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductImagesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddProductImagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId);

                if (product == null) return Result.NotFound("product is not exist");

                List<Image> images = new();

                foreach (var file in request.files)
                {
                    var path = await ImageHelper.SaveImageAsync(file, request.rootPath, request.folderName);

                    Image image = Image.Create(Path.GetFileName(path), request.ProductId, path);

                    images.Add(image);
                }

                await _unitOfWork.ImageRepository.AddRange(images);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no change");
                return Result.Success();
            } catch (Exception ex) {
                return Result.CriticalError("System Error");            
            }
        }
    }
}
