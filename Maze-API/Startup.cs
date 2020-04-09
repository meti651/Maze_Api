using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maze_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MazeGenerator;
using MazeGenerator.Models;
using MazePathFinder;
using MazePathFinder.Models;

namespace Maze_API
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
            services.AddDbContext<MazeDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddCors(opt => {
                opt.AddPolicy("_mazeFrontend",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3001")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddSingleton<ModelMazeGenerator>();
            services.AddSingleton<PathFinding>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("_mazeFrontend");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
