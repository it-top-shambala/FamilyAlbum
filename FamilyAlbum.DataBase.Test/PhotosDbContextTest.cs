using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FamilyAlbum.DataBase.Test;

public class PhotosDbContextTest
{
    [Fact]
    public void AddPhotoTest()
    {
        var db = new PhotosDbContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.AddPhoto("path", "comment");
        var actual = db.Photos.ToList();

        var expected = new List<Photo> { new("path", "comment") };
        
        Assert.Equal(expected, actual); //BUG
    }
}