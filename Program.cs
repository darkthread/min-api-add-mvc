using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// 指定 index.html 為 wwwroot 預設文件
app.UseDefaultFiles();
// 啟用 wwwroot 靜態檔資料夾
app.UseFileServer();

app.MapPost("/Sha1", async (HttpContext ctx) =>
{
    var hash = BitConverter.ToString(
        SHA1.Create().ComputeHash(
            Encoding.UTF8.GetBytes(ctx.Request.Form["data"].ToString())))
    .Replace("-", string.Empty);
    ctx.Response.ContentType = "text/html";
    await ctx.Response.WriteAsync($"<pre>{hash}</pre>");
});

app.Run();
