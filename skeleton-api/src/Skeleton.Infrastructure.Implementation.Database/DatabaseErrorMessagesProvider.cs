using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

public class DatabaseErrorMessagesProvider : IDatabaseErrorMessagesProvider
{
    public string UserXNameUniquenessViolation => "duplicate key value violates unique constraint \"ix_userXs_name\"";
}
