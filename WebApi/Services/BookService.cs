using WebApi.Context;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Services;

public class BookService
{
    private readonly DataContext _context;

    public BookService(DataContext context)
    {
        _context = context;
    }

    public List<GetBook> Books()
    {
        return _context.Books.Select(x => new GetBook()
        {
            Isbn = x.Isbn,
            Title = x.Title,
            Type = x.Type,
            Price = x.Price,
            PublishedDate = x.PublishedDate,
            Advance = x.Advance,
            PublisherId=x.Publisher.Id,
            YtdSales=x.YtdSales,
        }).ToList();
    }

    public GetBook GetBookByIsbn(string isbn)
    {
        var find = _context.Books.Find(isbn);
        return new GetBook()
        {
            Advance = find.Advance,
            PublishedDate = find.PublishedDate,
            PublisherId = find.PublisherId,
            Type = find.Type,
            Price = find.Price,
            YtdSales = find.YtdSales,
            Title = find.Title
        };
    }


    public AddBookDto AddBook(AddBookDto model)
    {
        model.PublishedDate = DateTime.SpecifyKind(model.PublishedDate, DateTimeKind.Utc);
        var book = new Book()
        {
            Advance = model.Advance,
            Isbn = model.Isbn,
            Price = model.Price,
            PublishedDate = model.PublishedDate,
            Title = model.Title,
            YtdSales = model.YtdSales,
            Type = model.Type,
            PublisherId = model.PublisherId
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        return model;
    }

    public AddBookDto UpdateBook(AddBookDto model)
    {
        model.PublishedDate = DateTime.SpecifyKind(model.PublishedDate, DateTimeKind.Utc);
        var find = _context.Books.Find(model.Isbn);
        find.Advance = model.Advance;
        find.PublishedDate = model.PublishedDate;
        find.PublisherId = model.PublisherId;
        find.Type = model.Type;
        find.Price = model.Price;
        find.YtdSales = model.YtdSales;
        find.Title = model.Title;
        return model;
    }

    public bool DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        _context.Books.Remove(book);
        var result = _context.SaveChanges();
        return result == 1;
    }



}