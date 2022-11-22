namespace FamilyAlbum.App.Models;

public class Photo : BaseNotification
{
    private string _path;
    public string ImagePath
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
        ImagePath = path;
        Comment = comment;
    }
}