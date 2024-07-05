using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;

namespace Skeleton.Infrastructure.Interfaces.Database;

public interface IDatabaseContext
{
    public DbSet<Blog> Blogs { get; }

    public DbSet<Post> Posts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
