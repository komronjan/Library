using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.BookAuthor;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookAuthorController : ControllerBase
{
    private readonly BookAuthorService _service;

    public BookAuthorController(BookAuthorService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    public List<GetBookAuthorDto> Get()
    {
        return _service.Get();
    }

    [HttpPost("Add")]
    public AddBookAuthorDto Add([FromForm] AddBookAuthorDto model)
    {
        return _service.Add(model);
    }

    [HttpPut("Update")]
    public AddBookAuthorDto Update([FromForm] AddBookAuthorDto model)
    {
        return _service.Update(model);
    }

    [HttpDelete("Delete")]
    public bool Delete(int authorId, string isbn)
    {
        return _service.Delete(authorId, isbn);
    }


}