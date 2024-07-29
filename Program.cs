using asp.net_task2.Data;
using asp.net_task2.Repositories;
using asp.net_task2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context
var connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True;";
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(connection);
});

// Configure dependency injection for repositories and services
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
