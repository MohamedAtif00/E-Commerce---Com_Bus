using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetDescription
{
    public class GetDescriptionQueryHandler : IQueryHandler<GetDescriptionQuery, GetDescriptionDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDescriptionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetDescriptionDto>> Handle(GetDescriptionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _unitOfWork.AdministrationRepository.GetAdministration();

                if (admin == null) return Result.Error("this no content");

                var description = admin._description;

                GetDescriptionDto dto = new GetDescriptionDto(description.Title_Eng, description.Title_Arb, description.Desc_Eng, description.Desc_Arb,description.Marquee_Eng,description.Marquee_Arb);

                return Result.Success(dto);

            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
