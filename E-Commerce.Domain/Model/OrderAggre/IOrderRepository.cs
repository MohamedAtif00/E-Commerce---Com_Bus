using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public interface IOrderRepository : IGenericRepository<Order, OrderId>
    {
        Task<List<Order>> GetLastDaysOrders(int days);
        Task<Order> GetOrderWithOrderItems(Order order);
        Task<IQueryable<Order>> GetPages();
    }
}
