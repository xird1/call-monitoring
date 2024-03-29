using Microsoft.EntityFrameworkCore;
using TelusInternational.Business;
using TelusInternational.Business.Services;
using TelusInternational.DataAccess;
using TelusInternational.DataAccess.Context;
using TelusInternational.DataAccess.Repositories;
using TelusInternational.DataAccess.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "CallMonitoringDb"));
builder.Services.AddScoped<DataInitializer>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQueueGroupRepository, QueueGroupRepository>();
builder.Services.AddScoped<IQueueGroupService, QueueGroupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedDatabase();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();


void SeedDatabase() //can be placed at the very bottom under app.Run()
{
    using (var scope = app.Services.CreateScope())
    {
        ApplicationDbContext context =  scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        DataInitializer.SeedData(context).Wait();
    }
}