namespace TwoOne.Domain.Common;

public class BaseEntity : BaseEntity<string>
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }
}

public class BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
}