using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _service;

    public BookController(BookService service)
    {
        _service = service;
    }

    [HttpGet("GetBooks")]
    public List<GetBook> GetBooks()
    {
        return _service.Books();
    }
    
    [HttpGet("GetBookByIsbn")]
    public GetBook GetBookByIsbn(string isbn)
    {
        return _service.GetBookByIsbn(isbn);
    }
    
    [HttpPost("AddBook")]
    public AddBookDto AddBook([FromForm]AddBookDto book)
    {
        return _service.AddBook(book);
    }

    [HttpPut("UpdateBook")]
    public AddBookDto UpdateBook([FromForm]AddBookDto book)
    {
        return _service.UpdateBook(book);
    }
    
    [HttpDelete("DeleteBook")]
    public bool DeleteBook(int id)
    {
        return _service.DeleteBook(id);
    }
    
    
}