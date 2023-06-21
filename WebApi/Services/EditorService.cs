using WebApi.Context;
using WebApi.Dtos.Editor;
using WebApi.Entities;

namespace WebApi.Services;

public class EditorService
{
    private readonly DataContext context;

    public EditorService(DataContext _context)
    {
        context = _context;
    }
    public List<GetEditorDto> Get()
    {
        return context.Editors.Select(x => new GetEditorDto()
        {
            Id = x.Id,
            Ssn = x.Ssn,
            Firstname = x.Firstname,
            Lastname = x.Lastname,
            Phone = x.Phone,
            EditorPosition = x.EditorPosition,
            Salary = x.Salary

        }).ToList();
    }
    public GetEditorDto GetById(int id)
    {
        var find = context.Editors.Find(id);
        var model = new GetEditorDto()
        {
            Id = find.Id,
            Ssn = find.Ssn,
            Firstname = find.Firstname,
            Lastname = find.Lastname,
            Phone = find.Phone,
            EditorPosition = find.EditorPosition,
            Salary = find.Salary,
        };
        return model;
    }
    public AddEditorDto Add(AddEditorDto model)
    {
        var editor = new Editor()
        {
            Id = model.Id,
            Ssn = model.Ssn,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Phone = model.Phone,
            EditorPosition = model.EditorPosition,
            Salary = model.Salary,
        };
        context.Editors.Add(editor);
        context.SaveChanges();
        return model;
    }
    public AddEditorDto Update(AddEditorDto model)
    {
        var find = context.Editors.Find(model.Id);
        find.Id = model.Id;
        find.Ssn = model.Ssn;
        find.Firstname = model.Firstname;
        find.Lastname = model.Lastname;
        find.Phone = model.Phone;
        find.EditorPosition = model.EditorPosition;
        find.Salary = model.Salary;
        context.SaveChanges();
        return model;
    }
    public bool Delete(int id)
    {
        var find = context.Editors.Find(id);
        context.Editors.Remove(find);
        context.SaveChanges();
        return true;
    }
}
