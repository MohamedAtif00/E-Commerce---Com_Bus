using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Application
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
    }
}
