using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.OrderConfig
{
    public class CouponRepository : GenericRepository<Coupon, CouponId>, ICouponRepository
    {
        public CouponRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Coupon> GetCouponByName(string code)
        {
            return await _context.coupons.Where(x => x.Code == code).SingleOrDefaultAsync();
        }
    }
}
