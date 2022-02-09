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
            var buffer = new byte[4096];
            var bytes = new List<byte>();
            while( Request.Body.ReadAsync(buffer, 0, buffer.Length).Result > 0 )
            {
                bytes.AddRange(buffer);
            }
            var result = Encoding.UTF8.GetString(bytes.ToArray());
            return Ok(result);
        }
    }
}
