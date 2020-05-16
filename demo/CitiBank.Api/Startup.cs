using CitiBank.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Xendor.ServiceLocator;
using Xendor.ServiceLocator.SimpleInjector;
using Xendor.ServiceLocator.SimpleInjector.Extensions;

namespace CitiBank.Api
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
            
            services.AddSimpleInjectorServiceLocator(options =>
            {
                options.AddAspNetCore().AddControllerActivation();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var serviceLocator = ServiceLocatorFactory.Instance();
            var container = (SimpleInjectorServiceLocator)ServiceLocatorFactory.Instance();
            app.UseSimpleInjector(container.Container);
            serviceLocator.InitializeContainer(Configuration);
           
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}