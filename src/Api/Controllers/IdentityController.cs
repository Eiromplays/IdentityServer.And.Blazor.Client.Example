using Duende.Bff;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[BffApi]
public class IdentityController : ControllerBase
{
    [HttpGet("me")]
    public IActionResult Get()
    {
        var response = new JsonResult(from c in User.Claims select new { c.Type, c.Value });

        Console.WriteLine($"Response {response.Value}");
        
        return response;
    }
}
