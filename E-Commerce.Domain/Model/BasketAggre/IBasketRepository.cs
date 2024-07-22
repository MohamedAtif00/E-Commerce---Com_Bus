using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.BasketAggre
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(Guid id);
        Task AddBasketAsync(Basket basket);
        Task RemoveBasketAsync(Guid id);
        Task UpdateBasketAsync(Basket basket);
    }
}
