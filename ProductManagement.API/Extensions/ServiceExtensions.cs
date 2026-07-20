using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.Data.Repositories;
using AutoMapper;
using ProductManagement.Application.Mapping;
using ProductManagement.Application.Services;
using ProductManagement.Infrastructure.Identity;
namespace ProductManagement.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddAutoMapper(typeof(ProductProfile));

        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}