using Microsoft.EntityFrameworkCore;
using ContactAppCS.DbContextFile;
using ContactAppCS.IRepos;
using ContactAppCS.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
//// Add the DbContext to the container.
builder.Services.AddDbContext<ContactAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactAppConnectionString")));

// Inject the EmployeeRepos class into the container.
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepos>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Replace with your Angular app URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowAngularApp");


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
