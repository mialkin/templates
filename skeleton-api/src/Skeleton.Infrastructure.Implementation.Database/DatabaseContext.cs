using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Implementation.Database.EntityTypeConfigurations;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

internal sealed class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());

        modelBuilder.Entity<User>().HasData([
            new User { Id = new Guid("272B950E-6835-4865-A924-C09750723145"), Username = "Michael" }
        ]);
    }
}
