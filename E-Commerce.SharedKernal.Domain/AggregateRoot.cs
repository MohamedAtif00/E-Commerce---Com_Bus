﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public abstract class AggregateRoot<TId> : Entity<TId>
         where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id) { }
    }

    public interface IAggregate
    { }
}
