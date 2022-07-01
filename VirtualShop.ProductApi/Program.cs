using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Repository;
using VirtualShop.ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(j=> j.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var version = new MySqlServerVersion(new Version(10, 6, 8));
    options.UseMySql(connectionString,version)
    .LogTo(Console.WriteLine,LogLevel.Information)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(c => c.AllowAnyOrigin());
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(c => c.AllowAnyOrigin());
app.MapControllers();

app.Run();
