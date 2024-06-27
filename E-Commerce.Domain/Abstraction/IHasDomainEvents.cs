using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Abstraction
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvents> DomainEvents { get; }

        public void ClearDomainEvents();
    }
}
