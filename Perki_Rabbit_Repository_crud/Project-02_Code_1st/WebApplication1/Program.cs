using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositiries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductDbContext>(option=> option.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<ICatagoryRepo, CatagoryRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
