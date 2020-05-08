using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CMS.API.Helper
{
    /// <summary>
    /// Contains the extension methods for handling Swagger
    /// </summary>
    public static class SwaggerServiceExtension
    {
        /// <summary>
        /// AddSwaggerDocumnetation
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumnetation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "Main CMC API v1.0",
                    Version = "v1.0",
                    Description = "An API to perform CMS Operations",
                    Contact = new OpenApiContact
                    {
                        Name = "Kumar Reddy S",
                        Email = "Komarareddys@gmail.com",
                        Url = new Uri("https://example.com/kumar")
                    },
                    License =new OpenApiLicense
                    {
                        Name = "Use Under Free Licence",
                        Url= new Uri("https://example.com/kumar")
                    }
                });

                c.AddSecurityDefinition("bearer",new OpenApiSecurityScheme
                { 
                  Description="JWT Authorization header using Bearer schema. Example: \"Authorization: Bearer {token}\"",
                  Name="Authorization",
                  In=ParameterLocation.Header,
                  Type=SecuritySchemeType.Http,
                  Scheme="bearer",
                  BearerFormat="JWT"
                });

                //Add uth header for [Authorize] endpoints
                c.OperationFilter<AuthentcationRequirementOperationFilter>();

                //Set the comments path for the swagger and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        /// <summary>
        /// UseSwaggerDocumentation
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c=> {

                c.SwaggerEndpoint("/swagger/v1.0/swagger.json","vesion API v1.0");
            });

            return app;
        }

        /// <summary>
        /// In the AuthentcationRequirementOperationFilter add
        /// </summary>
        public class AuthentcationRequirementOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();

                //The id value "bearer" metches what was passed as ther first parameter to 
                //AddSecurityDefination on AddSwaggerDocumentation
                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id="bearer"
                    }
                };
                operation.Security.Add(new OpenApiSecurityRequirement { 

                    [scheme] = new List<string>()

                });
            }
        }
    }
}
