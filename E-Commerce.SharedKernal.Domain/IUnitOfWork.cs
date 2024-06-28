﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        public

        Task<int> save();
    }
}
