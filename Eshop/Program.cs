using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using Eshop.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EshopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EshopContext") ?? throw new InvalidOperationException("Connection string 'EshopContext' not found.")));

 builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EshopContext>().AddDefaultTokenProviders();//Добавление датабазы ддля регистрации 



//здесь буду добавлять скопированное 2.7 2.8










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
