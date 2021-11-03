using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace YogaStudio.WebApi
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Yoga Studio API {apiVersion}",
                        Description = "Yoga Studio Weeb API.",
                        TermsOfService = new Uri("https://github.com/MaksimKushniruk"),
                        Contact = new OpenApiContact
                        {
                            Email = "reiysher25@gmail.com",
                            Name = "Maksim",
                            Url = new Uri("https://github.com/MaksimKushniruk")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Maksim",
                            Url = new Uri("https://github.com/MaksimKushniruk")
                        }
                    });
                options.AddSecurityDefinition($"AuthToken {apiVersion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorization",
                        Description = "Authorization token"
                    });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = $"AuthToken {apiVersion}"
                        }
                    },
                    new string[] { }
                    }
                });
                options.CustomOperationIds(apiDescritption =>
                    apiDescritption.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }
}
