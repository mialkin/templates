using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

internal sealed class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }
}
