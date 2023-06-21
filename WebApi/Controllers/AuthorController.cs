using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.Author;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _service;

    public AuthorController(AuthorService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    public List<GetAuthorDto> Get()
    {
        return _service.Get();
    }

    [HttpGet("GetById")]
    public GetAuthorDto GetById(int id)
    {
        return _service.GetById(id);
    }
    [HttpPost("Add")]
    public AddAuthorDto Add([FromForm] AddAuthorDto model)
    {
        return _service.Add(model);
    }

    [HttpPut("Update")]
    public AddAuthorDto Update([FromForm] AddAuthorDto model)
    {
        return _service.Update(model);
    }

    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
        return _service.Delete(id);
    }


}