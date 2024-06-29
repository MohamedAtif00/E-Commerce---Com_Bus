using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.SpecificationConfig
{
    public class SpecificationRepository : GenericRepository<Specification, SpecificationId>, ISpecificationRepository
    {
        public SpecificationRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
