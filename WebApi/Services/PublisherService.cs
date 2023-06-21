using System.Collections.Generic;
using WebApi.Context;
using WebApi.Dtos.Publisher;
using WebApi.Entities;

namespace WebApi.Services;

public class PublisherService
{
    private readonly DataContext context;

    public PublisherService(DataContext _context)
    {
        context = _context;
    }
    public List<GetPublisherDto> GetPublisher()
    {
        return context.Publishers.Select(x => new GetPublisherDto()
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            State = x.State,
        }).ToList();
    }
    public GetPublisherDto GetById(int id)
    {
        var find = context.Publishers.Find(id);
        var model = new GetPublisherDto()
        {
            Id = find.Id,
            Name = find.Name,
            Address = find.Address,
            State = find.State
        };
        return model;
    }
    public AddPublisherDto AddPublisher(AddPublisherDto model)
    {
        var book = new Publisher()
        {
            Id = model.Id,
            Name = model.Name,
            Address = model.Address,
            State = model.State
        };
        context.Publishers.Add(book);
        context.SaveChanges();
        return model;
    }
    public AddPublisherDto UpdatePublisher(AddPublisherDto model)
    {
        var find = context.Publishers.Find(model.Id);
        find.Address = model.Address;
        find.State = model.State;
        find.Name = model.Name;
        context.SaveChanges();
        return model;
    }
    public bool Delete(int id)
    {
        var find = context.Publishers.Find(id);
        context.Publishers.Remove(find);
        context.SaveChanges();
        return true; 
    }
}
