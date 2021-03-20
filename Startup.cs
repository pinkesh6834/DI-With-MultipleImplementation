using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_With_MultipleImplementation.Services;
using DI_With_MultipleImplementation.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DI_With_MultipleImplementation
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
            services.AddTransient<ServiceOne>();
            services.AddTransient<ServiceTwo>();
            services.AddTransient<ServiceThree>();

            services.AddTransient<ServiceResolver>(sp => key =>
            {
                switch (key) {
                    case "one":
                        return sp.GetService<ServiceOne>();
                    case "two":
                        return sp.GetService<ServiceTwo>();
                    case "three":
                        return sp.GetService<ServiceThree>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
