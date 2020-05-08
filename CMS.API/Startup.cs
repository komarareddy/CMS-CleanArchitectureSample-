using AutoMapper;
using CMS.API.Helper;
using CMS.Application.Helpers;
using CMS.Infrastructure;
using CMS.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CMS.API
{
    /// <summary>
    /// Entry point to application startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ctor of startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure Automapper service
            services.AddAutoMapper(typeof(Startup));

            //Service for valiading JWT
            services.ValidateJwtToken(Configuration);

            //Below line is for suppressing automatic response of WEB API
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();

            //Settings of connection globally
            services.AddDbContext1(Configuration);

            //Add custom services to system(IoC)
            DependencyContainer.RegisterServices(services, Configuration);

            //Register the Swagger generator
            services.AddSwaggerDocumnetation();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //This below middleware responsible for
            //Consistent response from APi(errors, success)
            app.UseCRMResponseWrapperMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //use swagger ui
            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseRouting();

            //Make the authentication service is available to the application
            app.UseAuthentication();
            //Below line enables authorization capabilities
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
