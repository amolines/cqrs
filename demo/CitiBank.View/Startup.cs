using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiBank.View.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using Xendor.QueryModel.AspNetCore;
using Xendor.ServiceLocator;
using Xendor.ServiceLocator.SimpleInjector;
using Xendor.ServiceLocator.SimpleInjector.Extensions;

namespace CitiBank.View
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
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new CriteriaModelBinderProvider());
            }).AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });
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
            serviceLocator.Verify();
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}