using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.MakeProductSpecialCommand
{
    public class MakeProductSpecialCommandHandler : ICommandHandler<MakeProductSpecialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakeProductSpecialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(MakeProductSpecialCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId,true);

                if (product == null) return Result.Error("this product is not exist");

                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();
                var group =  admin.Groups.Where(x => x.Id == request.GroupId).FirstOrDefault();

                if (group == null) return Result.Error("This Carsoul is not exist");

                product.MakeSpecial(group.Id);

                await _unitOfWork.ProductRepository.Update(product);

                int saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("There is no Change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
