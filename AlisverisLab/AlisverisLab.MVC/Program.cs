using AlisverisLab.BusinessLogic.Abstract;
using AlisverisLab.BusinessLogic.Concrete;
using AlisverisLab.BusinessLogic.DependencyResolver;
using AlisverisLab.BusinessLogic.ValidationRules;
using AlisverisLab.DataAccess.Abstract;
using AlisverisLab.DataAccess.Concrete.Entityframework;
using AlisverisLab.DataAccess.DbContext;
using AlisverisLab.DataAccess.FakeData;
using AlisverisLab.Entity.POCO;
using AlisverisLab.MVC.AutoMapperProfiler;
using AlisverisLab.MVC.Hubs;
using AlisverisLab.MVC.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7122");
});

builder.Services.AddSignalR();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//builder.Services.AddScoped<ICartDAL, EfCart>();
//builder.Services.AddScoped<ICategoryDAL, EfCategory>();
//builder.Services.AddScoped<IEmployeeDAL, EfEmployee>();
//builder.Services.AddScoped<IFavoriteDAL, EfFavorite>();
//builder.Services.AddScoped<ILogDAL, EfLog>();
//builder.Services.AddScoped<ILogTypeDAL, EfLogType>();
//builder.Services.AddScoped<IProductDAL, EfProduct>();
//builder.Services.AddScoped<IMediaDAL, EfMedia>();
//builder.Services.AddScoped<IMediaTypeDAL, EfMediaType>();
//builder.Services.AddScoped<IOrderDAL, EfOrder>();
//builder.Services.AddScoped<IOrderDetailDAL, EfOrderDetail>();
//builder.Services.AddScoped<IProductCategoryDAL, EfProductCategory>();
//builder.Services.AddScoped<IProductMediaDAL, EfProductMedia>();
//builder.Services.AddScoped<IShipperDAL, EfShipper>();


//builder.Services.AddScoped<ILogService, LogManager>();
//builder.Services.AddScoped<ICategoryService, CategoryManager>();
//builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
//builder.Services.AddScoped<IFavoriteService, FavoriteManager>();
//builder.Services.AddScoped<ICartService, CartManager>();
//builder.Services.AddScoped<ILogTypeService, LogTypeManager>();
//builder.Services.AddScoped<IMediaService, MediaManager>();
//builder.Services.AddScoped<IMediaTypeService, MediaTypeManager>();
//builder.Services.AddScoped<IOrderService, OrderManager>();
//builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
//builder.Services.AddScoped<IProductService, ProductManager>();
//builder.Services.AddScoped<IProductCategoryService, ProductCategoryManager>();
//builder.Services.AddScoped<IProductMediaService, ProductMediaManager>();
//builder.Services.AddScoped<IShipperService, ShipperManager>();
//builder.Services.AddDbContext<AlisverisLabDbContext>();

builder.Services.AddMemoryCache();

builder.Services.AddBussinessService();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<InvoiceService>();
builder.Services.AddSingleton<OrderService>();

//builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.User.RequireUniqueEmail = true;
	x.Password.RequiredLength = 3;
	x.Password.RequireNonAlphanumeric = false;
	x.Password.RequireUppercase = false;
	x.Password.RequireLowercase = false;
	x.Password.RequireDigit = false;

    x.SignIn.RequireConfirmedEmail = true;

}).AddEntityFrameworkStores<AlisverisLabDbContext>().AddDefaultTokenProviders();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryDTOValidationRule>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    options.Lockout.AllowedForNewUsers = true;

});

var app = builder.Build();

//Dummy.DataAdd();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

var orderService = app.Services.GetRequiredService<OrderService>();
orderService.StartListening();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

//app.UseMiddleware<SessionCheckMiddleware>();

app.MapHub<SiteViewHub>("/SiteViewHub");

app.MapAreaControllerRoute(
    areaName: "Admin",
    name: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
