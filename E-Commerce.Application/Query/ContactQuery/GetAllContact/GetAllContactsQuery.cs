using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.ContactQuery.GetAllContact
{
    public record GetAllContactsQuery():IQuery<List<Contact>>;
    
    
}
