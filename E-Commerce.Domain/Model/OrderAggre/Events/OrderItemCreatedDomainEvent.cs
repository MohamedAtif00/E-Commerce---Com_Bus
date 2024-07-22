using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.SharedKernal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre.Events
{
    public record OrderItemCreatedDomainEvent(ProductId ProductId,int quantity) : IDomainEvents;
    
    
}
