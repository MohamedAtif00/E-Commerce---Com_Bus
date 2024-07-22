using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.BasketAggre
{
    public class Basket : AggregateRoot<BasketId>
    {
        public Basket(BasketId id) : base(id)
        {
        }

        public List<BasketItem> basketItems { get; set; } = new();

        public static Basket Create(Guid value)
        {
            return new(BasketId.Create(value));
        }


    }
}
