﻿using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetAdministration
{
    public class GetAdministrationQueryHandler : IQueryHandler<GetAdministrationQuery, GetAdministrationDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAdministrationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetAdministrationDto>> Handle(GetAdministrationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var administrationRepository = _unitOfWork.AdministrationRepository;
                Administration? admin = await administrationRepository.GetAdministration();

                if (admin == null)
                {
                    var administration = Administration.Create();
                    administration.UpdateWebsiteColor("#FBD5D5");
                    return Result.Success(new GetAdministrationDto(administration._websiteColor,null,null,null,null));
                }

                var dto = new GetAdministrationDto(admin._websiteColor,
                                                   admin._welcomeMessage.Title_Eng,
                                                   admin._welcomeMessage.Title_Arb,
                                                   admin._welcomeMessage.Desc_Eng,
                                                   admin._welcomeMessage.Desc_Arb);

                return Result.Success(dto);
            }
            catch (Exception ex) 
            {
                return Result.CriticalError("system Error");
            }
        }
    }
}
