using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.AddCarsoulC_ommand
{
    public class AddCarsoulCommandHandler : ICommandHandler<AddCarsoulCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCarsoulCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddCarsoulCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var group = Group.Create(request.name);

                var administration = await _unitOfWork.AdministrationRepository.GetAdministration();
                administration.AddGroup(group);

                await _unitOfWork.AdministrationRepository.Update(administration);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error("System error ");    
            }
        }
    }
}
