using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.DataBase;

public sealed class PhotosDbContext : DbContext
{
    public DbSet<Photo> Photos { get; set; }

    public PhotosDbContext()
    {
        Database.EnsureCreated();
        Photos.Load();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=photos.db;");
    }

    public void AddPhoto(string path, string comment)
    {
        Photos.Add(new Photo(path, comment));
        SaveChanges(); //BUG
    }

    public void UpdatePhoto(int id, string path, string comment)
    {
        Photos.FirstOrDefault(p => p.Id == id).SetFields(path, comment);
        SaveChanges();
    }
}