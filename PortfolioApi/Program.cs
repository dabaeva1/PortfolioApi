using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<WorkContext>(opt =>
    opt.UseInMemoryDatabase("WorkList"));
builder.Services.AddDbContext<AboutContext>(opt =>
    opt.UseInMemoryDatabase("AboutList"));
builder.Services.AddDbContext<BlogContext>(opt =>
    opt.UseInMemoryDatabase("BlogList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
