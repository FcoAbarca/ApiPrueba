using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ApiTest.Models;
namespace ApiTest {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<_dbContext>( options => options.UseInMemoryDatabase( "ApiTest"));
               // "  .UseSqlServer( Configuration.GetConnectionString( "API" ) ) );
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, _dbContext context) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints => {
                endpoints.MapControllers();
            } );

            if (!context.Categorias.Any()) {
                context.Categorias.AddRange( new List<Categoria>() {
                    new Categoria() { categoria = "Nacional" },
                    new Categoria() { categoria = "Internacional" }
                } );
            }
            if (!context.Clientes.Any()) {
                context.Clientes.AddRange( new List<Cliente>() {
                    new Cliente() { categoriaID = 1,  nombres = "Juan", apellidos="Lopez" },
                    new Cliente() { categoriaID = 2, nombres= "Maria", apellidos= "Perez" }
                } );
            }
            context.SaveChanges();
        }
    }
}
