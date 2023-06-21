using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.Editor;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EditorController : ControllerBase
{
    private readonly EditorService _service;

    public EditorController(EditorService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    public List<GetEditorDto> Get()
    {
        return _service.Get();
    }

    [HttpGet("GetById")]
    public GetEditorDto GetById(int id)
    {
        return _service.GetById(id);
    }
    [HttpPost("Add")]
    public AddEditorDto Add([FromForm] AddEditorDto model)
    {
        return _service.Add(model);
    }

    [HttpPut("Update")]
    public AddEditorDto Update([FromForm] AddEditorDto model)
    {
        return _service.Update(model);
    }

    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
        return _service.Delete(id);
    }


}