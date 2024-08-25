using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.AddSpecialProductsCommand
{
    public class AddSpecialProductsCommandHandler : ICommandHandler<AddSpecialProductsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSpecialProductsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddSpecialProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var result = await _unitOfWork.SpecialProductsRepository.Add(SpecialProducts.Create(request.ProductId));

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }

        }
    }
}
