using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.ChangeTitleCommand
{
    public class ChangeWelcomeMessageCommandHandler : ICommandHandler<ChangeWelcomeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeWelcomeMessageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeWelcomeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();
                var welcome = new WelcomeMessage(request.title_Eng, request.title_Arb, request.message_Eng, request.message_Arb);
                int saving;
                if (admin == null)
                {
                    var newAdmin = Administration.Create();
                    var heroimage = HeroImage.Create(null);
                    newAdmin._welcomeMessage = welcome;
                    newAdmin._heroImage = heroimage;
                    newAdmin._welcomeMessage = welcome;
                    await _unitOfWork.AdministrationRepository.Add(newAdmin);

                    saving = await _unitOfWork.save();
                    if (saving == 0) return Result.Error("no change");

                    return Result.Success();
                }

                admin._welcomeMessage = welcome;

                await _unitOfWork.AdministrationRepository.Update(admin);

                saving = await _unitOfWork.save();
                if (saving == 0) return Result.Error("no change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.ToString()); 
            }
        }
    }
}
