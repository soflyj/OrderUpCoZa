using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using OrderUp.Application.Services;
using OrderUp.Domain.Entities;
using OrderUp.Application.Interfaces;
using FluentAssertions;
using OrderUp.Persistence;

public class TenantServiceTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly TenantService _service;

    public TenantServiceTests()
    {
        _mockContext = new Mock<IApplicationDbContext>();
        _service = new TenantService(_mockContext.Object);
    }

    [Fact]
    public async Task CreateTenant_ShouldAddTenant()
    {
        var tenant = new Tenant { Id = Guid.NewGuid(), Name = "Acme Corp" };

        _mockContext.Setup(x => x.Tenants.AddAsync(It.IsAny<Tenant>(), default));
        _mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        await _service.CreateTenantAsync(tenant);

        _mockContext.Verify(x => x.Tenants.AddAsync(It.Is<Tenant>(t => t.Name == "Acme Corp"), default), Times.Once);
        _mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }
}
