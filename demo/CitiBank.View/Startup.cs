using CitiBank.View.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
                // add custom binder to beginning of collection
                options.ModelBinderProviders.Insert(0, new CriteriaModelBinderProvider());
            }).AddJsonOptions(options => { options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSimpleInjectorServiceLocator(options =>
            {
                options.AddAspNetCore().AddControllerActivation();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var serviceLocator = ServiceLocatorFactory.Instance();



            var container = (SimpleInjectorServiceLocator)ServiceLocatorFactory.Instance();
            app.UseSimpleInjector(container.Container);

            serviceLocator.InitializeContainer(Configuration);
            serviceLocator.Verify();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
