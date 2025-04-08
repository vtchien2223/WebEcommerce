using DoAnCoSoWeb.Models;
using DoAnCoSoWeb.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, EFCompanyRepository>();
builder.Services.AddScoped<IWarehouseRepository, EFWarehouseRepository>();
builder.Services.AddScoped<ISaleRepository, EFSaleRepository>();
builder.Services.AddScoped<IRankRepository, EFRankRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
 AddCookie(options =>
 {
     options.Cookie.Name = "WaterCookie";
     options.LoginPath = "/User/Login";
 });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "trang-chu",
    pattern: "trang-chu",
    defaults: new { controller = "Home", action = "Index" });

    endpoints.MapControllerRoute(
    name: "mua-nhieu-nhat",
    pattern: "mua-nhieu-nhat",
    defaults: new { controller = "Home", action = "MostSold" });

    endpoints.MapControllerRoute(
    name: "them-san-pham",
    pattern: "them-san-pham",
    defaults: new { controller = "Product", action = "Create" });

    endpoints.MapControllerRoute(
    name: "danh-sach-loai-san-pham",
    pattern: "danh-sach-loai-san-pham",
    defaults: new { controller = "Category", action = "Index" });

    endpoints.MapControllerRoute(
    name: "them-loai-san-pham",
    pattern: "them-loai-san-pham",
    defaults: new { controller = "Category", action = "Create" });

    endpoints.MapControllerRoute(
    name: "sua-san-pham",
    pattern: "edit-san-pham/{id}",
    defaults: new { controller = "Product", action = "Edit" });

    endpoints.MapControllerRoute(
    name: "danh-sach-san-pham",
    pattern: "danh-sach-san-pham",
    defaults: new { controller = "Product", action = "Index" });

    endpoints.MapControllerRoute(
    name: "thong-bao",
    pattern: "thong-bao",
    defaults: new { controller = "Notificate", action = "Index" });

    endpoints.MapControllerRoute(
    name: "ho-tro",
    pattern: "ho-tro",
    defaults: new { controller = "Support", action = "Index" });

	endpoints.MapControllerRoute(
	name: "thongtin-lienhe",
	pattern: "thongtin-lienhe",
	defaults: new { controller = "Contact", action = "Index" });

	endpoints.MapControllerRoute(
    name: "dang-ky",
    pattern: "dang-ky",
    defaults: new { controller = "User", action = "Register" });

    endpoints.MapControllerRoute(
    name: "dang-nhap",
    pattern: "dang-nhap",
    defaults: new { controller = "User", action = "Login" });

    endpoints.MapControllerRoute(
    name: "thong-tin",
    pattern: "thong-tin",
    defaults: new { controller = "User", action = "Info" });

    endpoints.MapControllerRoute(
    name: "list-pay-pro",
    pattern: "list-pay-pro",
    defaults: new { controller = "User", action = "ListPaymentProduct" });

    endpoints.MapControllerRoute(
    name: "chi-tiet-san-pham",
    pattern: "san-pham/{id?}",
    defaults: new { controller = "Home", action = "ProdDetail" });

    endpoints.MapControllerRoute(
    name: "ram-san-pham",
    pattern: "ram-san-pham",
    defaults: new { controller = "Home", action = "RamProduct" });

    endpoints.MapControllerRoute(
    name: "ram-san-pham",
    pattern: "ram-san-pham",
    defaults: new { controller = "Home", action = "RamProduct" });

    endpoints.MapControllerRoute(
    name: "gio-hang",
    pattern: "gio-hang",
    defaults: new { controller = "Cart", action = "Index" });

    endpoints.MapControllerRoute(
    name: "them-gio-hang",
    pattern: "them-gio-hang",
    defaults: new { controller = "Cart", action = "AddItem" });

	endpoints.MapControllerRoute(
	name: "thanh-toan",
	pattern: "thanh-toan",
	defaults: new { controller = "Cart", action = "Payment" });

    endpoints.MapControllerRoute(
    name: "cap-nhat-thong-tin",
    pattern: "cap-nhat-thong-tin",
    defaults: new { controller = "User", action = "EditInfo" });

    endpoints.MapControllerRoute(
    name: "doi-mat-khau",
    pattern: "doi-mat-khau",
    defaults: new { controller = "User", action = "ChangePassword" });

    endpoints.MapControllerRoute(
    name: "doi-mat-khau-user",
    pattern: "doi-mat-khau-user",
    defaults: new { controller = "User", action = "ChangePasswordUser" });

    endpoints.MapControllerRoute(
    name: "quan-ly-account-user",
    pattern: "quan-ly-account-user",
    defaults: new { controller = "User", action = "AccountUser" });

    endpoints.MapControllerRoute(
    name: "tao-tai-khoan-user",
    pattern: "tao-tai-khoan-user",
    defaults: new { controller = "User", action = "RegisterAdmin" });

    endpoints.MapControllerRoute(
    name: "xoa-account-user",
    pattern: "xoa-account-user",
    defaults: new { controller = "User", action = "DeleteAccount" });

    endpoints.MapControllerRoute(
    name: "dang-xuat",
    pattern: "dang-xuat",
    defaults: new { controller = "User", action = "Logout" });

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


});

app.Run();