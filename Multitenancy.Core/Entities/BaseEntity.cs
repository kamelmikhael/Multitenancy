namespace Multitenancy.Core.Entities;

public abstract class BaseEntity : BaseEntity<int>
{ }

public abstract class BaseEntity<T>
{
    public T Id { get; private set; }
}
