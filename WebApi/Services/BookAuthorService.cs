using WebApi.Context;
using WebApi.Dtos.BookAuthor;
using WebApi.Entities;

namespace WebApi.Services;

public class BookAuthorService
{
    private readonly DataContext _context;

    public BookAuthorService(DataContext context)
    {
        _context = context;
    }

    public List<GetBookAuthorDto> Get()
    {
        return _context.BookAuthors.Select(x => new GetBookAuthorDto()
        {
            Isbn = x.Isbn,
            AuthorId = x.AuthorId,
            AuthorOrder = x.AuthorOrder,
            RoyaltyShare = x.RoyaltyShare,
            AuthorName = x.Author.Firstname,
            BookName = x.Book.Title
        }).ToList();
    }
    public AddBookAuthorDto Add(AddBookAuthorDto model)
    {
        var bookAuthor = new BookAuthor()
        {
            Isbn = model.Isbn,
            AuthorId = model.AuthorId,
            AuthorOrder = model.AuthorOrder,
            RoyaltyShare = model.RoyaltyShare,
        };
        _context.BookAuthors.Add(bookAuthor);
        _context.SaveChanges();
        return model;
    }

    public AddBookAuthorDto Update(AddBookAuthorDto model)
    {
        var find = _context.BookAuthors.Find(model.Isbn, model.AuthorId);
        find.AuthorOrder = model.AuthorOrder;
        find.RoyaltyShare = model.RoyaltyShare;
        return model;
    }

    public bool Delete(int authorId, string isbn)
    {
        var bookAuthor = _context.BookAuthors.Find(authorId, isbn);
        _context.BookAuthors.Remove(bookAuthor);
        var result = _context.SaveChanges();
        return result == 1;
    }



}