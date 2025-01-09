using Library.Application.Services;
using Library.DataAccess;
using Library.DataAccess.RepositorIes;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(
    options => 
    {
        options.UseMySql(builder.Configuration.GetConnectionString(nameof(LibraryDbContext)), new MySqlServerVersion(new Version(9, 0, 0)));
    });

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();


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
