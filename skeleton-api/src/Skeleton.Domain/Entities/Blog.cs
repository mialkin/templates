namespace Skeleton.Domain.Entities;

public class Blog
{
    public Guid Id { get; }

    public Guid UserXId { get; set; }

    public required UserX UserX { get; set; }

    public required string Name { get; set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}
