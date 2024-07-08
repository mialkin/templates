namespace Skeleton.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public required string Text { get; set; }

    public Guid UserTemplateId { get; set; }

    public required UserTemplate UserTemplate { get; set; }

    public Guid PostId { get; set; }

    public required Post Post { get; set; }
}
