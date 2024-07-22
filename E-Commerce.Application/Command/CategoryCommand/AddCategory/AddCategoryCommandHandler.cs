using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.CategoryCommand.AddCategory
{
    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = Category.Create(request.name);
                await _unitOfWork.CategoryRepository.Add(category);

                int saving = await _unitOfWork.save();
                if (saving == 0)
                {
                    return Result.Error("no change");
                }
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
