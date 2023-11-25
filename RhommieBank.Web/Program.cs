using Microsoft.AspNetCore.Authentication.Cookies;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Service.Services;
using RhommieBank.Web.Util;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(option =>
    {
        option.LoginPath = "/Login/Index";
        option.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IPersonService, PersonService>();
builder.Services.AddHttpClient<IBankService, BankService>();
builder.Services.AddHttpClient<IRekeningService, RekeningService>();
builder.Services.AddHttpClient<ILoginService, LoginService>();

SD.RhommieBankAPIBase = builder.Configuration["ServiceUrls:RhommieBankAPI"];

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IRekeningService, RekeningService>();
builder.Services.AddScoped<ILoginService, LoginService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
