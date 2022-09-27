using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using Eshop.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EshopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EshopContext") ?? throw new InvalidOperationException("Connection string 'EshopContext' not found.")));

 builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EshopContext>().AddDefaultTokenProviders();//Добавление датабазы ддля регистрации 



//здесь буду добавлять скопированное 2.7 2.8
builder.Services.Configure<IdentityOptions>(options => { options.Password.RequireDigit = true; 
    options.Password.RequiredLength = 6; 
    options.Password.RequireNonAlphanumeric = /*true*/ false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true; 
    options.Password.RequiredUniqueChars = /*6*/0;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = /*true*/ false; });


builder.Services.ConfigureApplicationCookie(options => { options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login"; 
    options.LogoutPath = "/Security/Account/Logout"; 
    options.SlidingExpiration = true; });






// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Products/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
