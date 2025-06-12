using Microsoft.AspNetCore.Http;
using OrderUp.Persistence;
using OrderUp.Domain.Entities;
using System.Net;
using System.Net.Http;

namespace OrderUp.Infrastructure.Middleware;

public class RequestLoggingMiddleware
{
  private readonly RequestDelegate _next;

  public RequestLoggingMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context, ApplicationDbContext db)
  {
    var log = new RequestLog
    {
      IPAddress = context.Connection.RemoteIpAddress?.ToString(),
      Location = "Unknown", // Placeholder (real IP2Geo API can be added)
      Path = context.Request.Path,
      Method = context.Request.Method
    };

    db.Add(log);
    await db.SaveChangesAsync();

    await _next(context);
  }
}
