namespace Skeleton.Domain.Entities;

public class Blog
{
    public Guid Id { get; }

    public Guid UserTemplateId { get; set; }

    public required UserTemplate UserTemplate { get; set; }

    public required string Name { get; set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}
