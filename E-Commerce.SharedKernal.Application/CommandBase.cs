﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Application
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }
        protected CommandBase()
        {
            Id = Guid.NewGuid();
        }
        protected CommandBase(Guid id)
        {
            Id = id;
        }
    }

    public abstract class  CommandBase<TResult>: ICommand<TResult>
    {
        public Guid Id { get; }
        protected CommandBase()
        {
            Id= Guid.NewGuid();
        }
        protected CommandBase(Guid id)
        {
            Id = id;
        }
    }

}