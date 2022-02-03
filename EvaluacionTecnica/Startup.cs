using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models.Context;
using Services.Interfaces;
using Services.Repositories;
using System;

namespace EvaluacionTecnica
{
    public class Startup
    {
        public readonly string _myCors = "MyCORS";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            object p = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EvaluacionTecnica", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: _myCors, builder =>
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBContext"));
            });

            services.AddScoped<IAuth, AuthRepo>();
            services.AddScoped<IRole, RoleRepo>();
            services.AddScoped<IUser, UserRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EvaluacionTecnica v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_myCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
