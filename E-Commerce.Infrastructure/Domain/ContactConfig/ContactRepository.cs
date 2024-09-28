using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ContactConfig
{
    public class ContactRepository : GenericRepository<Contact, ContactId>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
