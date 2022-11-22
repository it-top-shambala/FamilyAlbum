using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.DataBase;

public class Photo
{
    public int Id { get; set; }
    public string Path { get; set; }
    public string Comment { get; set; }

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
}