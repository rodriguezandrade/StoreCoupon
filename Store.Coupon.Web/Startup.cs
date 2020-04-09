using StoreCouponWeb.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.IO;

namespace StoreCouponWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureJWToken(Configuration);
            services.ConfigureCors();
            //services.ConfigureIISIntegration();
            services.ConfigureMySqlContext(Configuration);
            services.ConfigureClassesWithInterfaces();
            services.AutoMapperConfiguration();
            services.AddControllers();
            services.VersioningConfiguration();
            services.SwaggerConfiguration();
            services.ConfigureLoggerService();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Default values at Create project
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            #endregion
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(UISetup =>
            {
#if DEBUG
                // For Debug in Kestrel
                UISetup.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin");
                UISetup.SwaggerEndpoint("/swagger/v2/swagger.json", "Mobile");

#else
               // To deploy on IIS
                UISetup.SwaggerEndpoint("/StoreCoupon/swagger/v1/swagger.json", "Admin");
                UISetup.SwaggerEndpoint("/StoreCoupon/swagger/v2/swagger.json", "Mobile"); 
#endif 
            });
        }
    }
}
