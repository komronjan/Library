namespace WebApi.Dtos.BookAuthor;

public class GetBookAuthorDto : BookAuthorBaseDto
{
    public string AuthorName  { get; set; }
    public string BookName { get; set; }
}
