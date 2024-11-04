using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RedditClone.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint para obtener todos los usuarios
app.MapGet("/users", async (AppDbContext db) =>
{
    return await db.Users.ToListAsync();
})
.WithName("GetAllUsers")
.WithOpenApi();

// Puedes agregar más endpoints aquí para manejar Communities, Posts, Comments, Votes, etc.

app.Run();
