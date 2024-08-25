using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.SpecialProductsConfig
{
    public class SpecialProductsRepository : GenericRepository<SpecialProducts, SpecialProductsId>,ISpecialProductsRepository
    {
        public SpecialProductsRepository(ApplicationContext context) : base(context) 
        {
        }
    }
}
