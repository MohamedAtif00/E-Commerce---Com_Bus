using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class Coupon : Entity<CouponId>
    {
        public Coupon(CouponId id, string code, decimal discount, DateTime expirationDate, bool isActive, int usageLimit) : base(id)
        {
            Code = code;
            Discount = discount;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            UsageLimit = usageLimit;
        }

        public string Code { get; set; } // Coupon code
        public decimal Discount { get; set; } // Discount amount or percentage
        public DateTime ExpirationDate { get; set; } // When the coupon expires
        public bool IsActive { get; set; } // To track whether the coupon is active or used
        public int UsageLimit { get; set; } = int.MaxValue; // Number of times the coupon can be used
        public int UsageCount { get; set; } = 0; // Times the coupon has been used

        public static Coupon Create(string code,
                                                     decimal discount,
                                                     DateTime expirationDate,
                                                     bool isActive,
                                                     int usageLimit) {
            return new(CouponId.CreateUnique(),
                       code,
                       discount,
                       expirationDate,
                       isActive,
                       usageLimit);
        }

        public void UseCoupon()
        {
            if (UsageCount >= UsageLimit) {
                throw new InvalidOperationException("Usage limit has been exceeded.");
            }
            if(ExpirationDate < DateTime.UtcNow) throw new InvalidOperationException("this coupon has been expired.");

            UsageCount++;
        }


    }
}
