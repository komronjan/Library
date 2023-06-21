using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Dtos;
using WebApi.Dtos.Publisher;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly PublisherService _service;

    public PublisherController(PublisherService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    public List<GetPublisherDto> Get()
    {
        return _service.GetPublisher();
    }

    [HttpGet("GetById")]
    public GetPublisherDto GetById(int id)
    {
        return _service.GetById(id);
    }
    [HttpPost("Add")]
    public AddPublisherDto Add([FromForm] AddPublisherDto model)
    {
        return _service.AddPublisher(model);
    }

    [HttpPut("Update")]
    public AddPublisherDto Update([FromForm] AddPublisherDto model)
    {
        return _service.UpdatePublisher(model);
    }

    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
        return _service.Delete(id);
    }


}