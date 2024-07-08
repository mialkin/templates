using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Implementation.Database.EntityTypeConfigurations;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.Infrastructure.Implementation.Database;

internal sealed class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options), IDatabaseContext
{
    public DbSet<UserX> UserXs { get; set; }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserXEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());

        SeedTestData(modelBuilder);
    }

    private static void SeedTestData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserX>().HasData([
            new UserX { Id = new Guid("272B950E-6835-4865-A924-C09750723145"), Username = "Michael" },
            new UserX { Id = new Guid("AD4F3D9B-3D1A-43B7-B408-FDCF157125C2"), Username = "Luke" },
            new UserX { Id = new Guid("4F8EAB4F-1EB6-49C3-9FCA-F8CFB8CDC149"), Username = "Stephen" },
            new UserX { Id = new Guid("4C5979B4-73AF-49DC-B6EA-B9EED4BDC5CA"), Username = "Rich" }
        ]);
    }
}
