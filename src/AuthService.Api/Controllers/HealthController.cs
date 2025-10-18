using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "ok", service = "AuthService.Api" });
}