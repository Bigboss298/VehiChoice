using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using VehiChoice.Service.Interface;
using VehiChoice.Data;
using VehiChoice.Implementations.Repositories;
using VehiChoice.Implementations.Services;
using VehiChoice.Models.Entities;
using VehiChoice.Service.Interface;
using VehiChoice.Repository.Interface;
using VehiChoice.Service.Interface;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository,  CustomerRepository>();

builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();  

builder.Services.AddScoped<IBranchHeadService, BranchHeadService>();
builder.Services.AddScoped<IBranchHeadRepository, BranchHeadRepository>();

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddScoped<ICarService, CarService>(); 
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IDepositService, DepositService>();
builder.Services.AddScoped<IDepositRepository, DepositRepository>();
    
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/User/Login/";
                    config.Cookie.Name = "VehiChoice";
                    config.LogoutPath = "/User/Logout";
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
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();

app.UseAuthorization();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-NG"),
    SupportedCultures = new[] {new CultureInfo("en-NG") },
    SupportedUICultures = new[] {new CultureInfo("en-NG") },
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
