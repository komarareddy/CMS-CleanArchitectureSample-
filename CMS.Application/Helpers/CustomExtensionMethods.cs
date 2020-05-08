using CMS.Application.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Helpers
{
   public static class CustomExtensionMethods
    {
        public static Boolean IsValidJson(this string str)
        {
            bool isValidJson = false;
            str = str.Trim();
            if ((str.StartsWith("{") && str.EndsWith("}")) || str.StartsWith("[") && str.EndsWith("]"))
            {
                try
                {
                    var obj = JToken.Parse(str);
                    isValidJson = true;
                }
                catch (JsonReaderException jex)
                {
                    isValidJson = false;
                }
                catch (Exception ex)
                {
                    isValidJson = false;
                }
            }

            return isValidJson;
        }

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = string.Empty;
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            description = descriptionAttribute.Description;
                        }
                    }
                }
            }

            return description;
        }

        public static IApplicationBuilder UseCRMResponseWrapperMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMiddleware>();
        }



        //configure JWT authentication in our application
        //JWT’s support is built into ASP.NET Core 3.0 and we are going to configure an authentication middleware
        //for JSON web tokens
        public static IServiceCollection ValidateJwtToken(this IServiceCollection servicesCollection, IConfiguration configuration)
        {

            var jwtSettings = new JwtSettings();
            //Attempts to bind the given object instance to configuration values by matching property names against configuration keys recursively.
            configuration.Bind("JwtSettings", jwtSettings);

            // servicesCollection.AddSingleton(jwtSettings);
            //Below mentioned steps are used to configure JWT based authentication service
            servicesCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //this will validate last part of JWT using secret key
                    //The signing key must match!(i.e signing key coming from the client)
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),

                    //The issuer is the actual server that created the token (ValidateIssuer=true)
                    //Validate the server (ValidateIssuer = true) that generates the token.
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    //The receiver of the token is a valid recipient(ValidateAudience = true)
                    //Validate the recipient of token is authorized to receive(ValidateAudience = true)
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    //Validate the token expiry
                    ValidateLifetime = true

                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "True");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return servicesCollection;
        }

    }
}
