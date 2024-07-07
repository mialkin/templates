namespace Skeleton.Infrastructure.Interfaces.Database;

public interface IDatabaseErrorMessagesProvider
{
    public string UsernameUniquenessViolation { get; }
}
