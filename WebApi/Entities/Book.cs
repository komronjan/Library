using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class Book
{
    [Key]
    public string Isbn { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int PublisherId { get; set; }
    public decimal YtdSales { get; set; }
    public DateTime PublishedDate { get; set; }
    public decimal Advance { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual ICollection<BookEditor> BookEditors { get; set; }
    public virtual ICollection<BookAuthor> BookAuthors { get; set; }
}