using E_Commerce.Domain.Model.ReviewAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ReviewConfig
{
    public class ReviewRepository : GenericRepository<Review, ReviewId>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
