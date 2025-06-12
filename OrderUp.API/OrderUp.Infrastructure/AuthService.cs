using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderUp.Application.Interfaces;
using OrderUp.Application.Models;
using OrderUp.Domain.Entities;
using OrderUp.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderUp.Infrastructure.Services
{
  public class AuthService : IAuthService
  {
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }

    public async Task<AuthResponse> RegisterVendorAsync(VendorRegisterRequest request)
    {
      if (_context.Users.Any(u => u.Username == request.Username))
      {
        return new AuthResponse { Success = false, Message = "Username already exists." };
      }

      var user = new AppUser
      {
        Username = request.Username,
        Password = request.Password, // ⚠️ Should be hashed in production
        Role = "Vendor"
      };

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return new AuthResponse { Success = true, Message = "Vendor registered successfully." };
    }

    public async Task<AuthResponse?> AuthenticateVendorAsync(VendorLoginRequest request)
    {
      var user = _context.Users.FirstOrDefault(u =>
          u.Username == request.Username && u.Password == request.Password && u.Role == "Vendor");

      if (user == null)
        return null;

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
          }),
        Expires = DateTime.UtcNow.AddMinutes(15),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"]
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return new AuthResponse
      {
        Success = true,
        Token = tokenHandler.WriteToken(token),
        Message = "Authentication successful."
      };
    }
  }
}
