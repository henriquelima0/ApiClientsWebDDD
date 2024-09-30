using ApiClientsDDD.Application.Interfaces;
using ApiClientsDDD.Application.Service;
using ApiClientsDDD.Domain.Interfaces;
using ApiClientsDDD.Infrastructure.Data;
using ApiClientsDDD.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Razor Pages if you're using them
builder.Services.AddRazorPages();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register application services and repositories
builder.Services.AddScoped<IClientAppService, ClientAppService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Register Swagger services
builder.Services.AddEndpointsApiExplorer();  // Enables API endpoints for Swagger
builder.Services.AddSwaggerGen();  // Registers Swagger for API documentation

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Enable Swagger in development mode
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI available at the root URL
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map Razor Pages and Controllers
app.MapRazorPages();
app.MapControllers();  // Maps the controllers (essential for API routing)

app.Run();
