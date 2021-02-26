using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerTestCase.DAL;
using CareerTestCase.DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CareerTestCase.DAL.UnitOfWork;
using CareerTestCase.Business.Abstract;
using CareerTestCase.Business.Services;
using Swashbuckle.AspNetCore.Swagger;
using CareerTestCase.Configuration;

namespace CareerTestCase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DbServer"] ?? "localhost";
            var port = Configuration["DbPort"] ?? "1433";
            var user = Configuration["DbUser"] ?? "SA";
            var password = Configuration["Password"] ?? "Senol61gunes.";
            var database = Configuration["Database"] ?? "CareerDb";

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer($"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CareerTestCase", Version = "v1" });
            });
            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<ICVService, CVService>();
            services.AddTransient<IExperinceService, ExperinceService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IApplyService, ApplyService>();
            services.AddSingleton(AppConfiguration.ConfigureMapper());
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CareerTestCase");
                });
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CareerTestCase");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
                }
                catch (Exception ex)
                {
                    //logging
                }
            }
        }
    }
}
