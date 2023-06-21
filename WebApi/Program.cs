using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BookAuthorService>();
builder.Services.AddScoped<EditorService>();
builder.Services.AddScoped<BookEditorService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
