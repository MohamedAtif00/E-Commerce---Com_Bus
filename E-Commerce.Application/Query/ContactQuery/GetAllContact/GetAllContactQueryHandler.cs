using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ContactQuery.GetAllContact
{
    public class GetAllContactQueryHandler : IQueryHandler<GetAllContactsQuery, List<Contact>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllContactQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Contact>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contacts = await _unitOfWork.contactRepository.GetAll();

                return Result.Success(contacts);
            }
            catch (Exception ex) { 
                return Result.Error(ex.Message);
            }

        }
    }
}
