﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        public 

        Task<int> save();
    }
}
