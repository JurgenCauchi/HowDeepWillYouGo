using System.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Use a fixed localhost address
builder.WebHost.UseUrls("http://localhost:5050");

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Open the browser automatically
app.Lifetime.ApplicationStarted.Register(() =>
{
    Process.Start(new ProcessStartInfo
    {
        FileName = "http://localhost:5050",
        UseShellExecute = true
    });
});

app.Run();