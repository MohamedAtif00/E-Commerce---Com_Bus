using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CategoryCommand.DeleteCategory
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetById(request.CategoryId);

                if (category == null) return Result.Error("this category is not exist");

                await _unitOfWork.CategoryRepository.Delete(category);

     

                int saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("No change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
