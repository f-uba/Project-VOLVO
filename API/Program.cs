using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? sqliteConnection = builder.Configuration.GetConnectionString("SQLite");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(sqliteConnection));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}

app.Run();
