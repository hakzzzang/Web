
using Microsoft.EntityFrameworkCore;
using WebMiniProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(); //�ܼ� ����

//appsetting.json --> connectionString
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<AppDbContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//���Ǳ���� ��� �Ϸ��� �� �ۼ��ؾ� �մϴ�. build�� �ɼ��� ���״�� �ɼ� �������� ���� ������ app.UseSession()�� ���ؼ� ���� ����� �����մϴ�.
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Main}/{id?}");

app.Run();
