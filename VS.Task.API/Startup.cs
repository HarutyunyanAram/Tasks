using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using VS.Task.Business.Common;
using VS.Task.Data.Common;

namespace VS.Task.API
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
            services.AddDbContextPool<Data.TaskContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TaskDb")));

            services.BuildTaskDataServices();
            services.BuildTaskBusinessService();

            // add AutoMapper 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddProblemDetails();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VitruviSoft:Task - API",
                    Version = "v1", 
                    Description = "The API for test task.",
                    Contact = new OpenApiContact
                    {
                        Name= "Aram Harutyunyan",
                        Email = "aram.harutyunyan7.77@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/aram-harutyunyan/")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseProblemDetails();

            // enable swagger 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VitruviSoft: Task - API");
                c.RoutePrefix = string.Empty;
            });

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
