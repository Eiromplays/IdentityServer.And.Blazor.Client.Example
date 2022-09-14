using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var response = new JsonResult(from c in User.Claims select new { c.Type, c.Value });

        Console.WriteLine($"Response {response.Value}");
        
        return response;
    }
}
