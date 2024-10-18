using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ProductQuery.GetAllReviews
{
    public class GetAllReviewsQueryHandler : IQueryHandler<GetAllReviewsQuery, List<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Review>>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reviews = await _unitOfWork.ProductRepository.GetAllReviews();

                return Result.Success(reviews);
            }
            catch (Exception ex) {
                return Result.Error("System Error");
            }
        }
    }
}
