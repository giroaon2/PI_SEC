using PI_SEC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PI_SEC.Entities;
using PI_SEC.Interfaces;
using PI_SEC.Interfaces.Services;
using PI_SEC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<PiSecContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PiSecConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserRepositories, UserRepositories>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("user", new OpenApiInfo
    {
        Version = "v1",
        Title = "User API",
        Description = "User API",
    });
});

var app = builder.Build();

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
}).UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("../swagger/user/swagger.json", "User API");
    options.RoutePrefix = "swagger";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
