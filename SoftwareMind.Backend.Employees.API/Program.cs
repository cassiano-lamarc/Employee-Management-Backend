using Microsoft.EntityFrameworkCore;
using SoftwareMind.Backend.Employees.Infrasctructure.Context;
using SoftwareMind.Backend.Employees.Infrasctructure.Configurations;
using SoftwareMind.Backend.Employees.Application.Configurations;
using SoftwareMind.Backend.Employees.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFull",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});
// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddApplicationMediatR();
builder.Services.AddApplicationServices();

builder.Services.AddAuthorizationsServices(builder.Configuration);
builder.Services.AddSwaggerConfigurations();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseCors("AllowFull");

var imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "employees");

if (!Directory.Exists(imageDirectory))
{
    Directory.CreateDirectory(imageDirectory);
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
