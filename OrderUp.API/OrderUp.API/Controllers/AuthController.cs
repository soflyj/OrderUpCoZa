using Microsoft.AspNetCore.Mvc;
using OrderUp.Application.Interfaces;
using OrderUp.Application.Models;

namespace OrderUp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] VendorRegisterRequest request)
    {
      var result = await _authService.RegisterVendorAsync(request);
      if (!result.Success)
        return BadRequest(result.Message);

      return Ok(result);
    }

    [HttpPost("token")]
    public async Task<IActionResult> GetToken([FromBody] VendorLoginRequest request)
    {
      var tokenResult = await _authService.AuthenticateVendorAsync(request);
      if (tokenResult == null)
        return Unauthorized(new { message = "Invalid username or password." });

      return Ok(tokenResult);
    }
  }
}
