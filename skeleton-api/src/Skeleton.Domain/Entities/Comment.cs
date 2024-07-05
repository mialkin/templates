namespace Skeleton.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public required string Text { get; set; }

    public Guid UserId { get; set; }

    public required User User { get; set; }

    public Guid PostId { get; set; }

    public required Post Post { get; set; }
}
