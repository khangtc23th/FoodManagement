using Microsoft.EntityFrameworkCore;
using Web.Areas.Admin.Filters;
using wed.Models.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FoodContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FoodDb")));
builder.Services.AddSession(cfg =>
{
    cfg.Cookie.IsEssential = true;
    cfg.IdleTimeout = new TimeSpan(0, 15, 0); // khi đăng nhập web để im ru 15p sẽ hết hạn
});
builder.Services.AddMvc(cfg =>
{
    cfg.Filters.Add(new CustomActionFilters());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
