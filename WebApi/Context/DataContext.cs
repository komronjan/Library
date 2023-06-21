using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApi.Entities;

namespace WebApi.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookEditor> BookEditors { get; set; }
    public DbSet<Editor> Editors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(k => new { k.AuthorId, k.Isbn });
        modelBuilder.Entity<BookEditor>().HasKey(k => new { k.Isbn, k.EditorId });
        base.OnModelCreating(modelBuilder);
    }
}