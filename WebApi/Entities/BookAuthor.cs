using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class BookAuthor
{
    public int AuthorId { get; set; }
    public string Isbn { get; set; }
    public int AuthorOrder { get; set; }
    public decimal RoyaltyShare { get; set; }
    public Author Author { get; set; }
    [ForeignKey("Isbn")]
    public Book Book { get; set; }
}