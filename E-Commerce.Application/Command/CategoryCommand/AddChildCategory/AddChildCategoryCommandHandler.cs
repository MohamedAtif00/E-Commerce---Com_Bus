using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CategoryCommand.AddChildCategory
{
    public class AddChildCategoryCommandHandler : ICommandHandler<AddChildCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddChildCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var childCategory = request.pareantCategoryId != null ? ChildCategory.Create(request.name, request.pareantCategoryId) : ChildCategory.Create(request.name, null, request.parentChildCategoryId);

                await _unitOfWork.ChildCategoryRepository.Add(childCategory);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex) {
                return Result.CriticalError("System Error");
            }
        }
    }
}
