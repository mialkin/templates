using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

public class DatabaseErrorMessagesProvider : IDatabaseErrorMessagesProvider
{
    public string UserTemplateNameUniquenessViolation => "duplicate key value violates unique constraint \"ix_userTemplates_name\"";
}
