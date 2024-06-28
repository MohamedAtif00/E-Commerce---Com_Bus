using E_Commerce.Identity.Domain.Model;
using E_Commerce.SharedKernal.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Asbtraction
{
    public abstract class UserEntity : IdentityUser<UserId>,IHasDomainEvents, IEquatable<UserId>
    {
        protected static readonly List<IDomainEvents> _domainEvents = new();
        public UserId Id { get; protected set; }

        public IReadOnlyList<IDomainEvents> DomainEvents => _domainEvents.ToList();

        protected UserEntity(UserId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            return obj is UserEntity && Id.Equals(((UserEntity)obj).Id);
        }

        public bool Equals(UserEntity? other)
        {
            return Equals((object?)other);
        }

        public void AddDomainEvent(IDomainEvents domainEvents)
        {
            _domainEvents.Add(domainEvents);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public bool Equals(UserId? other)
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

        public static bool operator ==(UserEntity left, UserEntity right)
        {
            return Equals(right, left);
        }

        public static bool operator !=(UserEntity left, UserEntity right)
        {
            return !Equals(left, right);
        }


    }
}
