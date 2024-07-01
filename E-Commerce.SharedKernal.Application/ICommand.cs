using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Application
{
    public interface ICommand<T> :IRequest<Result<T>>
    {
    }

    public interface ICommand : IRequest<Result>
    { }
}
