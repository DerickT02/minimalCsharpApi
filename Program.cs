using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apifromscratch.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarsDBContext>(opt => opt.UseInMemoryDatabase("CarsDB"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();  
}

app.MapGet("/", () => "Hello Api");
app.UseHttpsRedirection();
 
app.UseAuthorization();

app.MapControllers();

app.Run();
