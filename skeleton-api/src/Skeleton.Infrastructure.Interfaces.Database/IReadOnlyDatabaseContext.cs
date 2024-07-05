using Skeleton.Domain.Entities;

namespace Skeleton.Infrastructure.Interfaces.Database;

public interface IReadOnlyDatabaseContext
{
    IQueryable<Blog> Blogs { get; }
}
