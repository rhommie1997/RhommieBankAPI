using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Service.Services;
using RhommieBank.Web.Util;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IPersonService, PersonService>();
builder.Services.AddHttpClient<IBankService, BankService>();
builder.Services.AddHttpClient<IRekeningService, RekeningService>();

SD.RhommieBankAPIBase = builder.Configuration["ServiceUrls:RhommieBankAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IRekeningService, RekeningService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
