using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeleton.Domain.Entities;

namespace Skeleton.Infrastructure.Implementation.Database.EntityTypeConfigurations;

internal class UserXEntityTypeConfiguration : IEntityTypeConfiguration<UserX>
{
    public void Configure(EntityTypeBuilder<UserX> builder)
    {
        builder.HasKey(x => new { x.Id });
        builder.HasIndex(x => new { x.Name }).IsUnique();
    }
}
