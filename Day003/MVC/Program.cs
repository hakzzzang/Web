var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // MVC 패턴으로 만들때 V와 C를 같이 사용
var app = builder.Build();

//app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name:"default",
    //pattern: "{controller=home}/{action=Index}/{id?}"
    //pattern:"{controller=First}/{action=First}/{id?}"
    pattern: "{controller=Home}/{action=About}/{id?}"
    );

app.Run();
