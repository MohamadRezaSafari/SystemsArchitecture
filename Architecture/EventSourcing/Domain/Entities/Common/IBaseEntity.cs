namespace Domain.Entities.Common;

public interface IBaseEntity<out TKey>
{
    TKey Id { get; }
}
