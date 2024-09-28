using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ContactAggre
{
    public class Contact : AggregateRoot<ContactId>
    {
        public Contact(ContactId id, string email, string name, string subject, string body) : base(id)
        {
            Email = email;
            Name = name;
            Subject = subject;
            Body = body;
        }

        public string Email { get;private set; }
        public string Name { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }


        public static Contact Create(string email,string name,string subject,string body)
        {
            return new(ContactId.CreateUnique(),email,name,subject,body);
        }
    }
}
