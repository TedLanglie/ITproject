using Microsoft.EntityFrameworkCore;
using RequestPrototype.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SymbolCompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SymbolCompanyDbContext")));

builder.Services.AddScoped<ISymbolCompanyRepository, EFSymbolCompanyRepository>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();