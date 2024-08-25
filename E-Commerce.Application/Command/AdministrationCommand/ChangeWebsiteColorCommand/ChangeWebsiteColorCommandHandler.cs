using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.ChangeWebsiteColorCommand
{
    public class ChangeWebsiteColorCommandHandler : ICommandHandler<ChangeWebsiteColorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeWebsiteColorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeWebsiteColorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();
                int saving;
                if (admin == null)
                {
                    var newAdmin = Administration.Create();
                    var heroimage = HeroImage.Create(null);
                    var welcome = new WelcomeMessage(null,null,null,null);
                    newAdmin.UpdateWebsiteColor(request.color);
                    newAdmin._heroImage = heroimage;
                    newAdmin._welcomeMessage = welcome;
                    await _unitOfWork.AdministrationRepository.Add(newAdmin);

                    saving = await _unitOfWork.save();
                    if (saving == 0) return Result.Error("no change");

                    return Result.Success();
                }

                admin.UpdateWebsiteColor(request.color);

                await _unitOfWork.AdministrationRepository.Update(admin);

                saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("Sytem Error");            
            }

        }

    }
}
