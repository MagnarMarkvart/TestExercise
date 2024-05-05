using Base.Contracts.Domain;

public abstract class BaseEntityId : BaseEntityId<Guid>, IDomainEntityId
{
}

public class BaseEntityId<TKey> : IDomainEntityId<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
}