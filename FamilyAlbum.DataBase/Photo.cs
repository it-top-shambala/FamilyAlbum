namespace FamilyAlbum.DataBase;

public class Photo : IEquatable<Photo>
{
    public int Id { get; set; }
    public string Path { get; set; }
    public string Comment { get; set; }

    public Photo()
    {
    }

    public Photo(string path, string comment)
    {
        Path = path;
        Comment = comment;
    }

    public void SetFields(string path, string comment)
    {
        Path = path;
        Comment = comment;
    }

    public bool Equals(Photo? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Path == other.Path && Comment == other.Comment;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Photo)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Path, Comment);
    }
}