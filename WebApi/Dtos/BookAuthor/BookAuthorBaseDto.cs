namespace WebApi.Dtos.BookAuthor;

public class BookAuthorBaseDto
{
    public int AuthorId { get; set; }
    public string Isbn { get; set; }
    public int AuthorOrder { get; set; }
    public decimal RoyaltyShare { get; set; }
}

