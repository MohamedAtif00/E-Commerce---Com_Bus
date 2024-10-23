using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.UpdateCarouselCommand
{
    public class UpdateCarouselCommandHandler : ICommandHandler<UpdateCarouselCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarouselCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateCarouselCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();

                var group = admin.Groups.Where(x =>x.Id == request.GroupId).FirstOrDefault();
                if (group == null) return Result.Error("This Carousel is not exist!");

                group.Update(request.name);

                await _unitOfWork.AdministrationRepository.Update(admin);

                int saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("No change detected!");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
