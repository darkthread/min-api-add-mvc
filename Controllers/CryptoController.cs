using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace min_api_add_mvc.Controllers
{
    public class CryptoController : Controller
    {
        [HttpPost]
        public IActionResult Sha1(string data)
        {
            var hash = BitConverter.ToString(
                    SHA1.Create().ComputeHash(
                        Encoding.UTF8.GetBytes(data.ToString())))
                .Replace("-", string.Empty);
            return Content($"<pre>{hash}</pre>", "text/html");
        }
    }
}
