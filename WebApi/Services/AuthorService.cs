using WebApi.Context;
using WebApi.Dtos.Author;
using WebApi.Entities;

namespace WebApi.Services;

public class AuthorService
{
    private readonly DataContext context;

    public AuthorService(DataContext _context)
    {
        context = _context;
    }
    public List<GetAuthorDto> Get()
    {
        return context.Authors.Select(x => new GetAuthorDto()
        {
            Id = x.Id,
            Ssn = x.Ssn,
            Firstname = x.Firstname,
            Lastname = x.Lastname,
            Phone = x.Phone,
            Address = x.Address,
            City = x.City,
            State = x.State,
            Zip = x.Zip

        }).ToList();
    }
    public GetAuthorDto GetById(int id)
    {
        var find = context.Authors.Find(id);
        var model = new GetAuthorDto()
        {
            Id = find.Id,
            Ssn = find.Ssn,
            Firstname = find.Firstname,
            Lastname = find.Lastname,
            Phone = find.Phone,
            Address = find.Address,
            City = find.City,
            State = find.State,
            Zip = find.Zip
        };
        return model;
    }
    public AddAuthorDto Add(AddAuthorDto model)
    {
        var author = new Author()
        {
            Id = model.Id,
            Ssn = model.Ssn,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Phone = model.Phone,
            Address = model.Address,
            City = model.City,
            State = model.State,
            Zip = model.Zip
        };
        context.Authors.Add(author);
        context.SaveChanges();
        return model;
    }
    public AddAuthorDto Update(AddAuthorDto model)
    {
        var find = context.Authors.Find(model.Id);
        find.Id = model.Id;
        find.Ssn = model.Ssn;
        find.Firstname = model.Firstname;
        find.Lastname = model.Lastname;
        find.Phone = model.Phone;
        find.Address = model.Address;
        find.City = model.City;
        find.State = model.State;
        find.Zip = model.Zip;
        context.SaveChanges();
        return model;
    }
    public bool Delete(int id)
    {
        var find = context.Authors.Find(id);
        context.Authors.Remove(find);
        context.SaveChanges();
        return true;
    }
}
