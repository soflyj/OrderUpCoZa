using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OrderUp.Application.Interfaces;
using OrderUp.Application.Services;
using OrderUp.Infrastructure.JWT;
using OrderUp.Infrastructure.Middleware;
using System.Text;

namespace OrderUp.Infrastructure;

public static class ServiceRegistration
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var jwtSection = configuration.GetSection("JwtSettings");
    services.Configure<JwtSettings>(jwtSection);

    var jwtSettings = jwtSection.Get<JwtSettings>();
    var key = Encoding.UTF8.GetBytes(jwtSettings!.Key);

    services.AddSingleton<JwtTokenGenerator>();

    services.AddAuthentication(opt =>
    {
      opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
      opt.RequireHttpsMetadata = false;
      opt.SaveToken = true;
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true
      };
    });

    return services;
  }
}
