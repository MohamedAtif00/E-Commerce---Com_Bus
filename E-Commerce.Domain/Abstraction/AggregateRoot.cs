
namespace E_Commerce.Domain.Abstraction
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id) { }
    }
}
