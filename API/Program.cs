using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Context;
using Application.Interfaces;
using Infrastructure.Persistence.UnitOfWork;
using AutoMapper;
using Application.Mapper;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Fleet Management",
        Version = "v1"
    });
});

string? sqliteConnection = builder.Configuration.GetConnectionString("SQLite");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(sqliteConnection));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(MapperProfile))!));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
