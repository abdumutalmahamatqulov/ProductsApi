using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Validations.Rules;
using ProductsApi.v1.Auth.Services.AuthServices;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Auth.Services.Interfaces;
using ProductsApi.v1.Auth.TokenGenerators;
using ProductsApi.v1.FileMetadata.Repositories;
using ProductsApi.v1.FileMetadata.Repositories.Interfaces;
using ProductsApi.v1.FileMetadata.Services;
using ProductsApi.v1.FileMetadata.Services.Interfaces;
using ProductsApi.v1.Products.Repositories;
using ProductsApi.v1.Products.Repositories.Interfaces;
using ProductsApi.v1.Products.Services;
using ProductsApi.v1.Products.Services.Interfaces;
namespace ProductsApi.v1.Auth.Services.Extentions;

public static class AddExtensionServices
{
    public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IFileMetadataService, FileMetadataService>();

        services.AddScoped<IFileMetadataRepository, FileMetadataRepository>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    public static void AddSwaggerService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var jwtSettings = configuration.GetSection("Jwt");
        services.AddSwaggerGen(p =>
        {
            p.ResolveConflictingActions(ad => ad.First());
            p.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                }
            );
            p.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                }
            );
        });

        services
            .AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])
                    )
                };
            });
    }
}
