using WebApi.Context;
using WebApi.Dtos.BookEditor;
using WebApi.Entities;

namespace WebApi.Services;

public class BookEditorService
{
    private readonly DataContext _context;

    public BookEditorService(DataContext context)
    {
        _context = context;
    }

    public List<GetBookEditor> Get()
    {
        return _context.BookEditors.Select(x => new GetBookEditor()
        {
            Isbn = x.Isbn,
            EditorId = x.Editor.Id,
            EditorName = x.Editor.Firstname,
            BookName = x.Book.Title
        }).ToList();
    }
    public GetBookEditor GetById(int editorId, string isbn)
    {
        var find = _context.BookEditors.Find(editorId, isbn);
        var model = new GetBookEditor()
        {
            Isbn = find.Isbn,
            EditorId = find.EditorId,
            EditorName = find.Editor.Firstname,
            BookName = find.Book.Title
        };
        return model;
    }
    public AddBookEditorDto Add(AddBookEditorDto model)
    {
        var bookEditor = new BookEditor()
        {
            Isbn = model.Isbn,
            EditorId = model.EditorId
        };
        _context.BookEditors.Add(bookEditor);
        _context.SaveChanges();
        return model;
    }

    public AddBookEditorDto Update(AddBookEditorDto model, int id)
    {
        var find = _context.BookEditors.Find(model.Isbn, model.EditorId);
        find.EditorId = id;
        return model;
    }

    public bool Delete(int editorId, string isbn)
    {
        var bookAuthor = _context.BookEditors.Find(editorId, isbn);
        _context.BookEditors.Remove(bookAuthor);
        var result = _context.SaveChanges();
        return true;
    }



}