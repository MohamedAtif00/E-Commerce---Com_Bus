using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ReviewAggre
{
    public class Review : AggregateRoot<ReviewId>
    {
        public Review(ReviewId id) : base(id)
        {
        }

        public CustomerId _customerId { get; private set; }
        public ProductId productId  { get; private set; }
        public string comment {  get; private set; }
        public Rating rating { get; private set; }
    }


}
