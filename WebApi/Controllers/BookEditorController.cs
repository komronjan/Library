using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.BookEditor;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookEditorController : ControllerBase
{
    private readonly BookEditorService _service;

    public BookEditorController(BookEditorService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    public List<GetBookEditor> Get()
    {
        return _service.Get();
    }

    [HttpGet("GetById")]
    public GetBookEditor GetById(int editorId, string isbn)
    {
        return _service.GetById(editorId, isbn);
    }
    [HttpPost("Add")]
    public AddBookEditorDto Add([FromForm] AddBookEditorDto model)
    {
        return _service.Add(model);
    }

    [HttpPut("Update")]
    public AddBookEditorDto Update([FromForm] AddBookEditorDto model, int id)
    {
        return _service.Update(model, id);
    }

    [HttpDelete("Delete")]
    public bool Delete(int editorId, string isbn)
    {
        return _service.Delete(editorId, isbn);
    }


}