using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.ProductCommands.AddReviewCommand
{
    public class AddReviewCommandHandler : ICommandHandler<AddReviewCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddReviewCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var review = Review.Create(request.comment,request.rating);

                var product = await _unitOfWork.ProductRepository.GetById(request.ProductId,true);


                product.AddReview(review);

                var allReviews = product.reviews;
                decimal total = allReviews.Select(x => x.rating).Sum() / allReviews.Count();

                product.AddTotalReviews(total);

                await _unitOfWork.ProductRepository.Update(product);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no change");

                return Result.Success();    


            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
