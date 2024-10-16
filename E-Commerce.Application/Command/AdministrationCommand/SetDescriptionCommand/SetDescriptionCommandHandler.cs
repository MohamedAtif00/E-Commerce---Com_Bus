using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.SetDescriptionCommand
{
    public class SetDescriptionCommandHandler : ICommandHandler<SetDescriptionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetDescriptionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetDescriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();
                var desc = new Description(request.title_eng, request.title_arb, request.desc_eng, request.title_arb,request.marquee_eng,request.marquee_arb);

                int saving;
                if (admin == null)
                {
                    var newAdmin = Administration.Create();
                    var heroimage = HeroImage.Create(null);
                    var welcome = new WelcomeMessage(null, null, null, null);
                    newAdmin.UpdateDescription(desc);
                    newAdmin._heroImage = heroimage;
                    newAdmin._welcomeMessage = welcome;
                    await _unitOfWork.AdministrationRepository.Add(newAdmin);

                    saving = await _unitOfWork.save();
                    if (saving == 0) return Result.Error("no change");

                    return Result.Success();
                }


                admin.UpdateDescription(desc);

                await _unitOfWork.AdministrationRepository.Update(admin);

                saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
