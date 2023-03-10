using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrellosKyBackAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TrellosKyBackAPI.Queries.Task;
using TrelloskyBack.Domain.Behaviors.TaskTrello;
using TrelloskyBack.Domain.Repositories.TaskTrello;
using TrellosKyBackAPI.Infrastructure.Repositories.TaskTrello;

namespace TrellosKyBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrellosKyBack", Version = "v1" });
            });

            //Tasks-----------------------

            //Queries
            services.AddScoped<ITaskQueries, TaskQueries>();

            //Behavior
            services.AddScoped<ITaskBehavior, TaskBehavior>();

            //Repository
            services.AddScoped<ITaskRepository, TaskRepository>();



            //Add Sql Server
            services.AddDbContext<ApplicationDbContext>
                (o => o.UseSqlServer(Configuration.
                GetConnectionString("TrelloConStr")));

            // Add Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Add Cors
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrellosKyBack v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
