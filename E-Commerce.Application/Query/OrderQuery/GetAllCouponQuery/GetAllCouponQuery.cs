using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.OrderQuery.GetAllCouponQuery
{
    public record GetAllCouponQuery():IQuery<List<Coupon>>;
    
    
}
