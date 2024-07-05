namespace Skeleton.Domain.Entities;

public class Blog
{
    public Guid Id { get; }

    public Guid UserId { get; set; }

    public required User User { get; set; }

    public required string Name { get; set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}
