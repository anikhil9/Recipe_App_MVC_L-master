using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipe_App;
using Recipe_App.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Recipe_AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Recipe_AppContext") ?? throw new InvalidOperationException("Connection string 'Recipe_AppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();  // Adds a default in-memory implementation of IDistributedCache.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set a short timeout for easy testing.
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;  // Make the session cookie essential.
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


