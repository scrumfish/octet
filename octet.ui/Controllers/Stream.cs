using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace octet.ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Octet : ControllerBase
    {
        [HttpPut]
        public IActionResult Put()
        {
            var bytes = new byte[4096];
            Request.Body.ReadAsync(bytes, 0, bytes.Length).Wait();
            var result = Encoding.UTF8.GetString(bytes);
            return Ok(result);
        }
    }
}
