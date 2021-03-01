using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dumb_storage.k8s.j5.Controllers
{
    [ApiController]
    public class DumbStorageController : ControllerBase
    {
        private readonly string _genshinFile;
        public DumbStorageController(IConfiguration config)
        {
            var storageDir = config["storageDir"];
            _genshinFile = $"{storageDir}/genshin.json";
        }

        [HttpGet("genshin")]
        public Task<string> GetGenshin() =>
            System.IO.File.ReadAllTextAsync(_genshinFile);

        [HttpPost("genshin")]
        public async Task<IActionResult> PostGenshin()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            await System.IO.File.WriteAllTextAsync(
                _genshinFile,
                await reader.ReadToEndAsync()
            );
            return NoContent();
        }
    }
}
