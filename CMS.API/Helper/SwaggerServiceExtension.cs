using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CMS.API.Helper
{
    public static class SwaggerServiceExtension
    {
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

                //Set the comments path for the swagger and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c=> {

                c.SwaggerEndpoint("/swagger/v1.0/swagger.json","vesion API v1.0");
            });

            return app;
        }
    }
}
