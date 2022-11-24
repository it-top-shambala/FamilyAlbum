using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.App.Models;

public sealed class PhotosDbContext : DbContext
{
    public DbSet<Photo> Photos { get; set; }

    public PhotosDbContext()
    {
        Database.EnsureCreated();
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