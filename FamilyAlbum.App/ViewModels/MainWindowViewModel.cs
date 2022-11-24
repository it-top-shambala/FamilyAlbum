using System.Collections.ObjectModel;
using System.Windows.Input;
using FamilyAlbum.App.Commands;
using FamilyAlbum.App.Models;
using Microsoft.Win32;

namespace FamilyAlbum.App.ViewModels;

public class MainWindowViewModel : BaseNotification
{
    private int _id;
    
    private Photo _selectedPhoto;
    public Photo SelectedPhoto
    {
        get => _selectedPhoto; 
        set => SetField(ref _selectedPhoto, value);
    }

    private string _comment;
    public string Comment
    {
        get => _comment; 
        set => SetField(ref _comment, value);
    }
    
    private string _path;
    public string ImagePath
    {
        get => _path; 
        set => SetField(ref _path, value);
    }

    public ObservableCollection<Photo> Photos { get; set; }

    public ICommand CommandOpenImage { get; set; }
    public ICommand CommandSave { get; set; }
    public ICommand CommandClear { get; set; }
    public ICommand CommandSelectionItem { get; set; }

    private readonly PhotosDbContext _db;

    public MainWindowViewModel()
    {
        _id = 0;
        
        _db = new PhotosDbContext();
        Photos = new ObservableCollection<Photo>(_db.Photos);
        SelectedPhoto = new Photo();

        CommandOpenImage = new LambdaCommand(_ => true, Open);
        CommandSave = new LambdaCommand(_ => true, Save);
        CommandClear = new LambdaCommand(_ => true, Clear);
        CommandSelectionItem = new LambdaCommand(_ => true, _ =>
        {
            _id = SelectedPhoto.Id;
            Comment = SelectedPhoto.Comment;
            ImagePath = SelectedPhoto.Path;
        });
    }

    private void Clear(object? o)
    {
        Comment = "";
        ImagePath = "";
        _id = 0;
    }
    private void Open(object? o)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"
        };
        var result = openFileDialog.ShowDialog();
        if ((bool)result)
        {
            ImagePath = openFileDialog.FileName;
        }
    }

    private void Save(object? o)
    {
        if (_id != 0)
        {
            _db.UpdatePhoto(_id, ImagePath, Comment);
        }
        else
        {
            Photos.Add(new Photo(ImagePath, Comment));
            _db.AddPhoto(ImagePath, Comment);
        }
        Clear(null);
    }
}