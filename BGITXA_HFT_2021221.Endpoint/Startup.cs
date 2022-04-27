using BGITXA_HFT_2021221.Data;
using BGITXA_HFT_2021221.Endpoint.Services;
using BGITXA_HFT_2021221.Logic;
using BGITXA_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ITelevisionLogic, TelevisionLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();

            services.AddTransient<ITelevisionRepository, TelevisionRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddSignalR();
            services.AddTransient<TelevisionShopDbContext, TelevisionShopDbContext>();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:38688"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
