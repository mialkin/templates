using Skeleton.Domain.Entities;

namespace Skeleton.Infrastructure.Interfaces.Database;

public interface IReadOnlyDatabaseContext
{
    IQueryable<User> Users { get; }

    IQueryable<Blog> Blogs { get; }

    IQueryable<Post> Posts { get; }

    IQueryable<Comment> Comments { get; }
}
