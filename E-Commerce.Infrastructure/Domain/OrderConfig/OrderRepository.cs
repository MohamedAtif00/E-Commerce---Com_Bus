using E_Commerce.Application.Helper;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IQueryable<Order>> GetPages()
        {
            return _context.orders;
        }

        public async Task<List<Order>> GetLastDaysOrders(int days)
        {
            // Use AsNoTracking for read-only queries if you don't need to track the entities
            return await _context.orders
                .AsNoTracking()
                .Where(x => x.CreatedDate >= DateTime.UtcNow.AddDays(-days))
                .ToListAsync();
        }

        public async Task<Order> GetOrderWithOrderItems(Order order)
        {
            return await _context.orders.Where(x => x == order).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrdersInProcess()
        {
            return await _context.orders.Where(x => x.TrackingNumber != null && x.State != OrderState.Cancelled && x.State != OrderState.Delivered && x.State != OrderState.Failed).ToListAsync();
        }

    }
}
