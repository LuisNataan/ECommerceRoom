using ECommerce.Project.Backend.Application.Interfaces;
using ECommerce.Project.Backend.Application.Services;
using ECommerce.Project.Backend.Domain.Interfaces;
using ECommerce.Project.Backend.Infra.Context;
using ECommerce.Project.Backend.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));
Environment.SetEnvironmentVariable("ConnectionString", connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
