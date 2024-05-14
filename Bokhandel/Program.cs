using Microsoft.EntityFrameworkCore;
using Bokhandel.Data;
using Bokhandel.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BokhandelContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("BokhandelContext"), new MySqlServerVersion(new Version(8, 0, 21))
        ?? throw new InvalidOperationException("Connection string 'BokhandelContext' not found.")));

//add identity
builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BokhandelContext>();
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add HttpContextAccessor service
builder.Services.AddHttpContextAccessor();

// Add Cart service
builder.Services.AddScoped<Cart>(sp => Cart.GetCart(sp));

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;



// try
// {
//     var context = services.GetRequiredService<BokhandelContext>();
//     SeedData.Initialize(context);
// }
// catch (Exception ex)
// {
//     var logger = services.GetRequiredService<ILogger<Program>>();
//     logger.LogError(ex, "An error occurred while seeding the database.");
// }

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
