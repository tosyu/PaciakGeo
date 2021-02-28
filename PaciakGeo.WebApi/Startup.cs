using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaciakGeo.WebApi.Extensions;

namespace PaciakGeo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterNodeBBExtensions(Configuration);
            services.RegisterUserExtensions();
            services.RegisterAuthenticationExtensions(Configuration);
            services.RegisterLocationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            if (Configuration.GetValue<bool>("UseAuthentication"))
            {
                app.UseAuthentication();
            }

            if (Configuration.GetValue<bool>("UseAuthorization"))
            {
                app.UseAuthorization();
            }

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}