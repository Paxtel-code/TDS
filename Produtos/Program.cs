using Microsoft.EntityFrameworkCore;
using ProdutosEFCore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProdutosContext>(
    // opt => opt.UseInMemoryDatabase("TodoList")
    opt => opt.UseSqlite(builder.Configuration.
    GetConnectionString("DefaultConnection"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
