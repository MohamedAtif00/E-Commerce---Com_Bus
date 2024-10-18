using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.DeleteCarouselCommand
{
    public class DeleteCarouselCommandHandler : ICommandHandler<DeleteCarouselCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarouselCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCarouselCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();

                var group = admin.Groups.Where(x => x.Id == request.GroupId).FirstOrDefault();

                if (group == null) return Result.Error("this Carousel is not exist");

                admin.DeleteGroup(group);

                await _unitOfWork.AdministrationRepository.Update(admin);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No chaneg");

                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
