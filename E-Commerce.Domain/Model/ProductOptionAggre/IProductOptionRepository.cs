using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductOptionAggre
{
    public interface IProductOptionRepository : IGenericRepository<ProductOption,ProductOptionId>
    {
    }
}
