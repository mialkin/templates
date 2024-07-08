using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

internal sealed class ReadOnlyDatabaseContext(IDatabaseContext databaseContext) : IReadOnlyDatabaseContext
{
    public IQueryable<UserX> UserXs => databaseContext.UserXs.AsNoTracking();

    public IQueryable<Blog> Blogs => databaseContext.Blogs.AsNoTracking();

    public IQueryable<Post> Posts => databaseContext.Posts.AsNoTracking();

    public IQueryable<Comment> Comments => databaseContext.Comments.AsNoTracking();
}
