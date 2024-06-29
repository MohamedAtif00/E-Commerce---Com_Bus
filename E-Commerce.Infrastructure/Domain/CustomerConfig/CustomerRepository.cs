using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.CustomerConfig
{
    public class CustomerRepository : GenericRepository<Customer, CustomerId>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
