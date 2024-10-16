using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class Review : Entity<ReviewId>
    {
        public Review(ReviewId id, string comment, int rating) : base(id)
        {
            Comment = comment;
            this.rating = rating;
        }


        public string Comment { get; set; }
        [Range(minimum:0,maximum:5)]
        public int rating { get; set; }

        public bool IsAllowed { get; set; } = false;

        public static Review Create(string comment,int rating)
        {
            return new(ReviewId.CreateUnique(),comment,rating);
        }

        public void AllowComment()
        {
            IsAllowed = true;
        }
    }
}
