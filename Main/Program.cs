using Main.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.Configure_DbContext(builder.Configuration);
builder.Services.Configure_Services_Registration();
builder.Services.Configure_Repository_Registration();
builder.Services.Configure_Session();
builder.Services.Configure_Identity();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles(); // wwwroot
app.UseRouting();


app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"); // area route üstte olmazsa route düzgün oluşmuyor
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Configure_And_Check_Migration();

app.Run();
