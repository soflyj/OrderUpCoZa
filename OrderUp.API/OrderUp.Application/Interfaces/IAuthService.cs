using OrderUp.Application.Models;
using System.Threading.Tasks;

namespace OrderUp.Application.Interfaces
{
  public interface IAuthService
  {
    Task<AuthResponse> RegisterVendorAsync(VendorRegisterRequest request);
    Task<AuthResponse?> AuthenticateVendorAsync(VendorLoginRequest request);
  }
}
