namespace Skeleton.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public required string Text { get; set; }

    public Guid UserXId { get; set; }

    public required UserX UserX { get; set; }

    public Guid PostId { get; set; }

    public required Post Post { get; set; }
}
