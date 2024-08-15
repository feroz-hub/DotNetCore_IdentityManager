using System.Runtime.InteropServices;
using IdentityManagerMVC.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "DefaultConnection" : "DockerDb");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
var app = builder.Build();


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
