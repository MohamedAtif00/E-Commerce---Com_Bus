﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvents> DomainEvents { get; }

        public void ClearDomainEvents();
    }
}