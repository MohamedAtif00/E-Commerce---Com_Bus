using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.OrderConfig
{
    public class OrderRepository : GenericRepository<Order, OrderId>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
