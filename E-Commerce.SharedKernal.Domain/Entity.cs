using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public abstract class Entity<TId> : IHasDomainEvents, IEquatable<TId>
         where TId : notnull
    {
        protected static  List<IDomainEvents> _domainEvents = new();
        public TId Id { get; protected set; }

        public IReadOnlyList<IDomainEvents> DomainEvents => _domainEvents.ToList();

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            return obj is Entity<TId> && Id.Equals(((Entity<TId>)obj).Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public void AddDomainEvent(IDomainEvents domainEvents)
        {
            _domainEvents.Add(domainEvents);
        }

        public List<IDomainEvents> GetDomainEvents() => _domainEvents.ToList();
        

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public bool Equals(TId? other)
        {
            if (other is null)
                return false;

            return Id.Equals(other);
        }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(right, left);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }


    }
}
