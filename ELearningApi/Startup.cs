using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElearningApp.Data;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ELearningApi
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IConfiguration config, ILoggerFactory loggerFactory)
        {
            _config = config;
            _loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = _config.GetConnectionString("DefaultConnection"); 
            services.AddDbContext<ELearningDataContext>(opt => opt.UseSqlServer(connectionString));

            var logger = _loggerFactory.CreateLogger<Startup>();
            logger.LogDebug("Starting application");

            logger.LogDebug("Adding Service Dependencies...");

            services.AddIdentity<BaseUser, BaseRole>()
                .AddEntityFrameworkStores<ELearningDataContext>();

            services.ConfigureApplicationCookie(config =>
            {
                config.Events.OnRedirectToLogin = (ctx) =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api")
                    && ctx.Response.StatusCode == 200)
                        ctx.Response.StatusCode = 401;

                    return Task.CompletedTask;
                };

                config.Events.OnRedirectToAccessDenied = (ctx) =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api")
                    && ctx.Response.StatusCode == 200)
                        ctx.Response.StatusCode = 403;

                    return Task.CompletedTask;
                };
            });

            //services.AddScoped<IRepository<Student>, StudentRepo>();

            //services.AddScoped<IService<StudentResponse, StudentRequest>, StudentService>();

            services.AddScoped<IStudentRepository, StudentRepo>();

            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
