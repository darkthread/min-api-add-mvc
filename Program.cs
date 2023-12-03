using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 啟用 Controller
builder.Services.AddControllers();

var app = builder.Build();

// 指定 index.html 為 wwwroot 預設文件
app.UseDefaultFiles();
// 啟用 wwwroot 靜態檔資料夾
app.UseFileServer();

// 指定 Controller 路由
app.MapControllers();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
