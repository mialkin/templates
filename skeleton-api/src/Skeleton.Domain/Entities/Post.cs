namespace Skeleton.Domain.Entities;

public class Post
{
    public int Id { get; set; }

    public int BlogId { get; set; }

    public required string Title { get; set; }

    public required string Text { get; set; }

    public bool Archived { get; set; }

    public DateTime CreatedAt { get; set; }

    public required Blog Blog { get; set; }
}
