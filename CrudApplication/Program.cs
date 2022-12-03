using CrudApplication.Data;
using CrudApplication.Data.Repository;
using CrudApplication.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuring your CRUDAppDbContext.cs
builder.Services.AddDbContext<CRUDAppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDAppDatabase")));

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
