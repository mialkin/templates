using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;

namespace Skeleton.Infrastructure.Interfaces.Database;

public interface IDatabaseContext
{
    public DbSet<UserX> UserXs { get; }

    public DbSet<Blog> Blogs { get; }

    public DbSet<Post> Posts { get; }

    public DbSet<Comment> Comments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
