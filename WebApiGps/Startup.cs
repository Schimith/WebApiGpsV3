using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Dependencias
using WebApiGps.Models;
using WebApiGps.Services;
using WebApiGps.IServices;
using Microsoft.EntityFrameworkCore;


namespace WebApiGps
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
            //WebPage Default
            services.AddRazorPages();

            //API
            services.AddControllers();
            services.AddHttpClient();
            services.AddDbContext<EMPRESAContext>(options =>
                     options.UseSqlServer(Configuration["DbConnection"]));

            //Caçambas
            services.AddTransient<ICacambaService, CacambaService>();
            //Localização
            services.AddTransient<ILocalizacaoService, LocalizacaoService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //WebPage Default
                endpoints.MapRazorPages();
                //API
                endpoints.MapControllers();
            });
        }
    }
}
