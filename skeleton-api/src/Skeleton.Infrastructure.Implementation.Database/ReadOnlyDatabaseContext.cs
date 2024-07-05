using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

internal sealed class ReadOnlyDatabaseContext(IDatabaseContext databaseContext) : IReadOnlyDatabaseContext
{
    public IQueryable<Blog> Blogs => databaseContext.Blogs.AsNoTracking();
}
