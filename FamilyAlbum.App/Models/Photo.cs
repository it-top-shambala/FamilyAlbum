namespace FamilyAlbum.App.Models;

public class Photo : BaseNotification
{
    public int Id { get; set; }
    
    private string _path;
    public string Path
    {
        get => _path; 
        set => SetField(ref _path, value);
    }

    private string _comment;
    public string Comment
    {
        get => _comment; 
        set => SetField(ref _comment, value);
    }

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
}