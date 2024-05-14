
using System.Collections.Immutable;

namespace Domain.Entities.Common;

public abstract class BaseAggregateRoot<TA, TKey>
    : BaseEntity<TKey>, IAggregateRoot<TKey> where TA : IAggregateRoot<TKey>
{
    private readonly Queue<IDomainEvent<TKey>> events = new Queue<IDomainEvent<TKey>>();

    protected BaseAggregateRoot() { }

    protected BaseAggregateRoot(TKey id) : base(id)
    {

    }

    protected void AddEvent(IDomainEvent<TKey> @event)
    {
        if (@event is null) throw new ArgumentNullException(nameof(@event));

        events.Enqueue(@event);
        Apply(@event);
        Version++;
    }

    protected abstract void Apply(IDomainEvent<TKey> @event);

    public long Version { get; private set; }

    public IReadOnlyCollection<IDomainEvent<TKey>> Events => events.ToImmutableArray();

    public void ClearEvents()
    {
        events.Clear();
    }
}
