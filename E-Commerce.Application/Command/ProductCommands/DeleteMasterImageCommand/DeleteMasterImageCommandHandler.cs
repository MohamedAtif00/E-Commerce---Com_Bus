using Ardalis.Result;
using E_Commerce.Application.Helper;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.DeleteMasterImageCommand
{
    public class DeleteMasterImageCommandHandler : ICommandHandler<DeleteMasterImageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMasterImageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteMasterImageCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var masterImage = await _unitOfWork.ImageRepository.GetMasterImageByProductId(request.ProductId);

                var result = ImageHelper.DeleteImage(masterImage.Path, request.webRootPath);

                if (!result)
                {
                    return Result.Error("the master image didn't change");
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }
    }
}
