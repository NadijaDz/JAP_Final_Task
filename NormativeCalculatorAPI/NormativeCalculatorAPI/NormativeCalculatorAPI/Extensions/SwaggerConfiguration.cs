using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace NormativeCalculator.API.Extensions
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection RegisterSwaggerConfiguration(this IServiceCollection services, IConfiguration config)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NormativeCalculatorAPI", Version = "v1" });
                c.AddSecurityDefinition("Cookie", new OpenApiSecurityScheme
                {
                    Description = @"Cookies header using the Oauth2. \r\n\r\n 
                      Enter 'auth_cokie' [space] and then your cookies in the text input below.
                      \r\n\r\nExample: 'auth_cokie hdsjfshfbjshdgfj'",
                    Name = "auth_cookie",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "auth_cookie",
                      
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {new OpenApiSecurityScheme(){
                    Reference = new OpenApiReference()
                    {
                        Id = "auth_cookie",
                        Type = ReferenceType.SecurityScheme
                    }
                    }, new List<string>() }
                });
            });

            return services;
        }
    }
}
