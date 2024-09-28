using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ContactCommand.AddContact
{
    public class AddContactCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<AddContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = Contact.Create(request.email,request.name,request.subject,request.body);

                await _unitOfWork.contactRepository.Add(contact);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No change");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
