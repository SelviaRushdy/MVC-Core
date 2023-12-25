using Microsoft.EntityFrameworkCore;
using MVC_Core.DbContexts;
using MVC_Core.Services;
using Microsoft.AspNetCore.Identity;
using MVC_Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddEntityFrameworkStores<MVC_CoreContext>();
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
    .AddEntityFrameworkStores<MVC_CoreContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddDbContextPool<MVC_CoreContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
