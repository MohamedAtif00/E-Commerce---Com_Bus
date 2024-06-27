using E_Commerce.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class Brand : Entity<BrandId>
    {
        private Brand(BrandId id) : base(id)
        {
        }

        public string _name { get;private set; }

    }
}
