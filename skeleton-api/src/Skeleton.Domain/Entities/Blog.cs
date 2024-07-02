namespace Skeleton.Domain.Entities;

public class Blog
{
    public Blog(string name)
    {
        Name = name;
    }

    public int Id { get; }

    public string Name { get; private set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}
