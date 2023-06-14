using Catalog.Persistence.Database;
using Catalog.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Catalog.Api
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
            //Con la siguiente línea de código se le está diciendo a el ApplicationDbContext
            //que va a trabajar con SQL Server
            services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog")

                ));
            //Con esto va a cargar todo el assmbly 'Catalog.Services.EventHandlers' y así se evita registrar comando por comando.
            //Como se expone una clase por método y no una clase con muchos métodos, el 'Catalog.Services.EventHandlers' va a crecer mucho.
            services.AddMediatR(Assembly.Load("Catalog.Services.EventHandlers"));
            services.AddTransient<IProductQueryService, ProductQueryService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }           

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
