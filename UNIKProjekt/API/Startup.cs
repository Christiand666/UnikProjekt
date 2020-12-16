using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Handlers;
using Application.Classes;

namespace API
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
            services.AddSession();

            services.AddDbContext<DB>(options =>
                options.UseMySQL("Server=176.20.155.226;Port=3306;Database=unik_projekt;user=unik_projekt;password=12345678"));

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IDB, DB>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApartmentHandler, ApartmentHandler>();
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAuth, UserAuth>();
            services.AddScoped<IWaitingListPrio, WaitingListHandler>();
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
