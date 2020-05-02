namespace AwesomeProjectStructurev1
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using IocServiceStack.Config;

    using Org.Domain.WebApi;
    using Org.Domain.Abstractions.Common;
    using Org.Domain.Common;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Configre Next level Ioc for Business Services
            ConfgureNextLevelDI(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private static void ConfgureNextLevelDI(IServiceCollection services)
        {
            services.AddSingleton(typeof(IBusinessService<>), typeof(BusinessService<>));

            var cotnainer = IocServiceStackConfig.Configure();

            cotnainer.GetSharedContainer()
                    .Add<ISettings>(() => new Settings() { ConnectionString = "" });
        }
    }
}
