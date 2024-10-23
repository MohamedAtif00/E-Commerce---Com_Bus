using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CategoryCommand.DeleteChildCategory
{
    public class DeleteChildCategoryCommandHandler : ICommandHandler<DeleteChildCategoryCommand>
    {
        private readonly IUnitOfWork  _unitOfWork;

        public DeleteChildCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteChildCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAll();
                var child = await _unitOfWork.ChildCategoryRepository.GetById(request.id);
                await _unitOfWork.ChildCategoryRepository.Delete(child);

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
