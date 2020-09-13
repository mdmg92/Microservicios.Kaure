﻿using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Microservicios.Kaure.Cross.Jwt
{
    public static class Extensions
    {
        private static readonly string JwtSectionName = "jwt";
        public static IServiceCollection AddJwtCustomized(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var options = configuration.GetOptions<JwtOptions>(JwtSectionName);

            if (options.Enabled)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Key));
                services.AddAuthentication()
                    .AddJwtBearer("SECURITY-TOKEN", opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = options.Issuer,
                            ValidAudience = options.Audience,
                            IssuerSigningKey = signingKey
                        };
                    });
            }

            return services;
        }
        
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }
    }
}
