using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models.Models.Implementation;
using PalasProject.Repositories;
using PalasProject.Repositories.Interfaces;

namespace PalasProject
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureDbContext(IServiceCollection services, string connString)
        {

            services.AddDbContext<PalasContext>(
            op => op.UseSqlServer(connString,
                m => m.MigrationsAssembly("PalasProject")));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IParkingRepo<ParkingSpot>, ParkingSpotRepo>();
            services.AddScoped<IParkingRepo<ParkingLot>, ParkingLotRepo>();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });

            var connString = Configuration.GetConnectionString("PalasConnString");
            ConfigureDbContext(services, connString);
        }
    }
}